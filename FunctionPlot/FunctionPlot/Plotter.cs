using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionPlot {
    internal class Plotter {
        private double x_start, x_end;
        private const double INVALID_VAL = double.PositiveInfinity;
        private List<string> post_order; // convert input into a post_order traversal and store in list
        private Stack<string> operators; // operators on the top have higher priority than the remainings in the stack
        private const string all_operators = "*/+-()";
        private static List<string> all_funcs = new List<string>() { "log", "sin", "cos", "tan" };
        /// <summary>
        /// Plotter constructor.
        /// </summary>
        public Plotter() {
            post_order = new List<string>();
            operators = new Stack<string>();
        }

        /// <summary>
        /// Validate the input. Return error message if input is invalid, otherwise return empty string.
        /// </summary>
        public string validate_input(string fun, string start, string end) {
            string s = fun.ToLower();
            if (s.Length == 0)
                return "Input is void";

            if (s.Contains('\t') || s.Contains(' ') || s.Contains('\n'))
                return "Input contains spaces";

            if (s.Contains('>') || s.Contains('<') || s.Contains('=') || s.Contains('!') || s.Contains('^'))
                return "Input contrains invalid operators";

            if (s.StartsWith("*") || s.StartsWith("/"))
                return "Input starts with operator *,/";

            if (s.EndsWith("+") || s.EndsWith("-") || s.EndsWith("*") || s.EndsWith("/") || s.EndsWith("("))
                return "Input ends with +,-,*,/,(";

            string acc = "";
            for (int i = 0; i < s.Length; i++) {
                char c = s[i];
                // if current element is an operator
                if (is_operator(ref c)) {
                    if (acc.Length > 0) {
                        // if acc is a function before the current operator
                        if (is_function(acc)) {
                            if (c != '(') // check whether function name is followed by '('
                                return "function should be followed by (";
                            if (invalide_continuous_operators(ref s, i - acc.Length - 1))
                                return "Input contains invalid continuous operators";
                            operators.Push(acc); // add the function to operators
                        }
                        else {
                            if (!is_operand(acc)) // if acc is a operand before the current operator, it must consist of number, decimal point or x
                                return "Invalid operand";
                            post_order.Add(acc); // add operand to post_order
                        }
                        acc = "";
                    }
                    // if there's another operator just before the current operator, check whether this combination is valid
                    else if (i > 0 && invalide_continuous_operators(s[i - 1], c))
                        return "Input contains invalid continuous operators";

                    string op = c.ToString();
                    // if operators in the stack have higher priority, process them first
                    if (operators.Count > 0 && !higher_priority(op, operators.Peek())) {
                        // ')' has the highest priority, pop out operators between '(' and ')'
                        if (operators.Peek() == ")") {
                            if (!handle_parenthesis())
                                return "( is missing";
                        }
                        // pop out operators in the stack still encounter one with lower priority or stack is empty
                        while (operators.Count > 0 && !higher_priority(op, operators.Peek()))
                            post_order.Add(operators.Pop());
                    }

                    operators.Push(op);
                }
                else
                    acc += c;
            }

            if (acc.Length > 0) {
                if (is_function(acc))
                    return "function should be followed by (";
                if (!is_operand(acc))
                    return "Invalid operand";
                post_order.Add(acc); // add the last operand
            }
            // if parenthesis exists in the stack, pop out operators between '(' and ')'
            if (operators.Count > 0 && operators.Peek() == ")") {
                if (!handle_parenthesis())
                    return "( is missing";
            }
            // pop out operators excluding '(' and ')'
            while (operators.Count > 0) {
                if (operators.Peek() == "(") // ')' is missing
                    return ") is missing";
                post_order.Add(operators.Pop());
            }

            // convert X range to numbers
            x_start = process_x(ref start);
            if (x_start == INVALID_VAL)
                return "Invalid x range";

            x_end = process_x(ref end);
            if (x_end == INVALID_VAL || x_start >= x_end)
                return "Invalid x range";

            return "";
        }

        /// <summary>
        /// Add operators between '(' and ')' to stack. Return false if error.
        /// </summary>
        private bool handle_parenthesis() {
            operators.Pop(); //remove ')'
            while (operators.Count > 0 && operators.Peek() != "(")
                post_order.Add(operators.Pop());

            if (operators.Count == 0)  // '(' is missing
                return false;

            operators.Pop(); // remove '('
            return true;
        }

        /// <summary>
        /// Return true if the priority of cur is higher than that of prev. Operator with higher priority is processed sooner
        /// </summary>
        private bool higher_priority(string cur, string prev) {
            if (cur == "+" || cur == "-")
                return prev == "(";

            if (cur == "*" || cur == "/")
                return (prev == "+") || (prev == "-") || (prev == "(");

            if (cur == "(")
                return true;

            if (cur == ")")
                return prev != ")";

            return true;  // cur is function
        }

        /// <summary>
        /// Check whether input is an operator.
        /// </summary>
        private bool is_operator(ref char c) {
            return all_operators.Contains(c);
        }

        /// <summary>
        /// Check whether input is a function.
        /// </summary>
        private bool is_function(string op) {
            return all_funcs.Contains(op);
        }

        /// <summary>
        /// Check whether input is a valid operand.
        /// </summary>
        private bool is_operand(string s) {
            if (s.Length == 1)
                return (s == "x") || (s[0] >= '0' && s[0] <= '9');

            foreach (var c in s) {
                if (c != '.' && !(c >= '0' && c <= '9'))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Check whether two consecutive operators constitute a valid combination.
        /// </summary>
        private bool invalide_continuous_operators(char prev, char cur) {
            if ("+*/)".Contains(cur))
                return "+-*/(".Contains(prev);

            if (cur == '-')
                return "+-*/".Contains(prev);

            if (cur == '(')
                return ")".Contains(prev);

            return true;
        }

        /// <summary>
        /// Check whether the operator at pos, which is before the function name is valid.
        /// </summary>
        private bool invalide_continuous_operators(ref string s, int pos) {
            return !(pos < 0 || s[pos] != ')');
        }

        /// <summary>
        /// Return Xs and Ys for plotting. Xs are between [-100, 100] by default.
        /// </summary>
        public List<KeyValuePair<double, double>> get_xys() {
            List<KeyValuePair<double, double>> xy = new List<KeyValuePair<double, double>>();
            double step = 1;
            // The number of points between [x_start, x_end] should be [min_points, max_points]
            int min_points = 1000, max_points = 5000;
            double len = x_end - x_start;
            if (len < min_points)
                step = len / min_points;
            else if (len > max_points)
                step = len / max_points;

            for (var x = x_start; x <= x_end; x += step) {
                double y = computey(x);
                if (y != INVALID_VAL) // if Y is valid, add X and Y to result.
                    xy.Add(new KeyValuePair<double, double>(x, y));
            }

            return xy;
        }

        /// <summary>
        /// Compute the output for each input X.
        /// </summary>
        private double computey(double x) {
            List<double> acc = new List<double>();

            foreach (string ele in post_order) {
                if (is_operand(ele)) {
                    if (ele == "x")
                        acc.Add(x);
                    else
                        acc.Add(double.Parse(ele)); // convert numbers into double-precison floating point
                }
                else {
                    double y;
                    // unary operatior: either '+', '-' or functions
                    if (acc.Count == 1 || is_function(ele)) {
                        double a = acc.Last();
                        acc.RemoveAt(acc.Count - 1);
                        y = unary_operator(ele, ref a);
                    }
                    else // binary operatior
                    {
                        double b = acc.Last();
                        acc.RemoveAt(acc.Count - 1);
                        double a = acc.Last();
                        acc.RemoveAt(acc.Count - 1);
                        y = binary_operator(ele, ref a, ref b);
                    }
                    if (y == INVALID_VAL)
                        return y;
                    acc.Add(y);
                }
            }
            return acc.Last();
        }

        /// <summary>
        /// Return the result of op imposed to operand a.
        /// </summary>
        private double unary_operator(string op, ref double a) {
            switch (op) {
                case "+":
                    return a;
                case "-":
                    return -a;
                case "sin":
                    return Math.Sin(a);
                case "cos":
                    return Math.Cos(a);
                case "tan":
                    double n = a / (Math.PI / 2);
                    if (n % 1 == 0 && (Convert.ToInt32(n) & 1) == 1) // input shouldn't be n*(pi/2), n != (2m + 1)
                        break;
                    return Math.Tan(a);
                default:  // op == "log"
                    if (a <= 0)
                        break;
                    return Math.Log(a, 2);
            }
            return INVALID_VAL;
        }

        /// <summary>
        /// Return the result of op imposed to operand a and b.
        /// </summary>
        private double binary_operator(string op, ref double a, ref double b) {
            switch (op) {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    if (b == 0)
                        break;
                    return a / b;
            }
            return INVALID_VAL;
        }

        /// <summary>
        /// Clear data in post_order list and operators stack.
        /// </summary>
        public void clear_data() {
            post_order.Clear();
            operators.Clear();
        }

        /// <summary>
        /// Convert x range to a number. Return inf if error.
        /// </summary>        
        private double process_x(ref string s) {
            if (s.Length == 0)
                return INVALID_VAL;

            double res;
            bool succeed = double.TryParse(s, out res);
            if (!succeed)
                return INVALID_VAL;
            return res;
        }

        /// <summary>
        /// Return the post order list. Used for debug only.
        /// </summary>
        public List<string> get_postorder() {
            return post_order;
        }

        /// <summary>
        /// Return Xs and Ys for plotting. Used for debug only.
        /// </summary>
        public List<KeyValuePair<double, double>> plot_test_data() {
            var points = new List<KeyValuePair<double, double>> {
                new KeyValuePair<double, double>(-10, 2),
                new KeyValuePair<double, double>(-5, 5),
                new KeyValuePair<double, double>(0, 6),
                new KeyValuePair<double, double>(3, 12)
                };
            return points;
        }
    }
}
