Basic windows calculator replacement for those who likes operator precedence and keyboard input.

(c)opyright Måns Andersson 2011-2012

## Value input and output

The calculator can handle input of values in three forms, hex, decimal and bit form. When the result is an integer the result is presented in all three forms, for floating point results only decimal form is presented.

* **Hex** 0x5b
* **Decimal** 91
* **Bit** 0b1011011

## Function support

* **abs** absolute value, e.g. abs(-1)=1
* **floor** floor value, e.g. floor(1.6)=1
* **ceil** ceiling value, e.g. ceil(1.3)=2
* **round** rounded value, e.g. round(1.5)=2
* **ln** natural logarithm, e.g. ln(e)=1
* **log** 10 logarithm, e.g. log(100)=2
* **sin** sine (NB! radian input), e.g. sin(0)=0
* **cos** cosine (NB! radian input), e.g. cos(pi)=-1
* **tan** tangent (NB! radian input)
* **sqrt** square root, e.g. sqrt(4)=2

## Calculator Modes

The calculator have two different modes built in which gives it somewhat different evaluations of the expression. You change the Calculator Mode by typing the command and pressing Enter.

### Mathematics Mode (command: m)

Evaluates expressions as a regular calculator. You may input values both in hex, decimal and bit form. Available operators:

* +
* -
* *
* / (floating point division)
* ^ (exponential calculation e.g. 10^2 = 100)
* AND (bitwise and)
* OR (bitwiso or)
* XOR (bitwise xor)
* NOT (bitwise not)

### Programming Mode (command: p)

Evaluates expressions more like a programming language would, e.g. the division is integer division when both operands are integers. You may input values in both hex, decimal and bit form. Available operators:

* +
* -
* *
* / (integer division when both operands are integers, else floating point division)
* & (bitwise and)
* | (bitwise or)
* ^ (bitwise xor)
* ~ (bitwise not)