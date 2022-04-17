namespace CalculatorFinal
{
    public partial class Calculator : Form
    {
        private Rectangle oneButtonOriginalRectangle;
        private Rectangle twoButtonOriginalRectangle;
        private Rectangle threeButtonOriginalRectangle;
        private Rectangle fourButtonOriginalRectangle;
        private Rectangle fiveButtonOriginalRectangle;
        private Rectangle sixButtonOriginalRectangle;
        private Rectangle sevenButtonOriginalRectangle;
        private Rectangle eightButtonOriginalRectangle;
        private Rectangle nineButtonOriginalRectangle;
        private Rectangle ButtonZeroOriginalRectangle;
        private Rectangle BINButtonOriginalRectangle;
        private Rectangle DECButtonOriginalRectangle;
        private Rectangle equalButtonOriginalRectangle;
        private Rectangle plusButtonOriginalRectangle;
        private Rectangle minusButtonOriginalRectangle;
        private Rectangle divideButtonOriginalRectangle;
        private Rectangle multiplyButtonOriginalRectangle;
        private Rectangle backspaceButtonOriginalRectangle;
        private Rectangle clearButtonOriginalRectangle;
        private Rectangle LOCButtonOriginalRectangle;
        private Rectangle displayLabelOriginalRectangle;
        private Size originalFormSize;
        public Calculator()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            originalFormSize = this.Size;
            oneButtonOriginalRectangle = new Rectangle(oneButton.Location.X, oneButton.Location.Y, oneButton.Width, oneButton.Height);
            twoButtonOriginalRectangle = new Rectangle(twoButton.Location.X, twoButton.Location.Y, twoButton.Width, twoButton.Height);
            threeButtonOriginalRectangle = new Rectangle(threeButton.Location.X, threeButton.Location.Y, threeButton.Width, threeButton.Height);
            fourButtonOriginalRectangle = new Rectangle(fourButton.Location.X, fourButton.Location.Y, fourButton.Width, fourButton.Height);
            fiveButtonOriginalRectangle = new Rectangle(fiveButton.Location.X, fiveButton.Location.Y, fiveButton.Width, fiveButton.Height);
            sixButtonOriginalRectangle = new Rectangle(sixButton.Location.X, sixButton.Location.Y, sixButton.Width, sixButton.Height);
            sevenButtonOriginalRectangle = new Rectangle(sevenButton.Location.X, sevenButton.Location.Y, sevenButton.Width, sevenButton.Height);
            eightButtonOriginalRectangle = new Rectangle(eightButton.Location.X, eightButton.Location.Y, eightButton.Width, eightButton.Height);
            nineButtonOriginalRectangle = new Rectangle(nineButton.Location.X, nineButton.Location.Y, nineButton.Width, nineButton.Height);
            ButtonZeroOriginalRectangle = new Rectangle(ButtonZero.Location.X, ButtonZero.Location.Y, ButtonZero.Width, ButtonZero.Height);
            backspaceButtonOriginalRectangle = new Rectangle(backspaceButton.Location.X, backspaceButton.Location.Y, backspaceButton.Width, backspaceButton.Height);
            BINButtonOriginalRectangle = new Rectangle(BINButton.Location.X, BINButton.Location.Y, BINButton.Width, BINButton.Height);
            clearButtonOriginalRectangle = new Rectangle(clearButton.Location.X, clearButton.Location.Y, clearButton.Width, clearButton.Height);
            DECButtonOriginalRectangle = new Rectangle(DECButton.Location.X, DECButton.Location.Y, DECButton.Width, DECButton.Height);
            LOCButtonOriginalRectangle = new Rectangle(LOCButton.Location.X, LOCButton.Location.Y, LOCButton.Width, LOCButton.Height);
            multiplyButtonOriginalRectangle = new Rectangle(multiplyButton.Location.X, multiplyButton.Location.Y, multiplyButton.Width, multiplyButton.Height);
            divideButtonOriginalRectangle = new Rectangle(divideButton.Location.X, divideButton.Location.Y, divideButton.Width, divideButton.Height);
            minusButtonOriginalRectangle = new Rectangle(minusButton.Location.X, minusButton.Location.Y, minusButton.Width, minusButton.Height);
            equalButtonOriginalRectangle = new Rectangle(equalButton.Location.X, equalButton.Location.Y, equalButton.Width, equalButton.Height);
            plusButtonOriginalRectangle = new Rectangle(plusButton.Location.X, plusButton.Location.Y, plusButton.Width, plusButton.Height);
            displayLabelOriginalRectangle = new Rectangle(displayLabel.Location.X, displayLabel.Location.Y, displayLabel.Width, displayLabel.Height);

        }

        private void Calculator_Resize(object sender, EventArgs e)
        {
            resizeControl(oneButtonOriginalRectangle, oneButton);
            resizeControl(twoButtonOriginalRectangle, twoButton);
            resizeControl(threeButtonOriginalRectangle, threeButton);
            resizeControl(fourButtonOriginalRectangle, fourButton);
            resizeControl(fiveButtonOriginalRectangle, fiveButton);
            resizeControl(sixButtonOriginalRectangle, sixButton);
            resizeControl(sevenButtonOriginalRectangle, sevenButton);
            resizeControl(eightButtonOriginalRectangle, eightButton);
            resizeControl(nineButtonOriginalRectangle, nineButton);
            resizeControl(ButtonZeroOriginalRectangle, ButtonZero);
            resizeControl(backspaceButtonOriginalRectangle, backspaceButton);
            resizeControl(BINButtonOriginalRectangle, BINButton);
            resizeControl(clearButtonOriginalRectangle, clearButton);
            resizeControl(DECButtonOriginalRectangle, DECButton);
            resizeControl(LOCButtonOriginalRectangle, LOCButton);
            resizeControl(multiplyButtonOriginalRectangle, multiplyButton);
            resizeControl(divideButtonOriginalRectangle, divideButton);
            resizeControl(minusButtonOriginalRectangle, minusButton);
            resizeControl(equalButtonOriginalRectangle, equalButton);
            resizeControl(plusButtonOriginalRectangle, plusButton);
            resizeControl(displayLabelOriginalRectangle, displayLabel);
        }

        private void resizeControl(Rectangle OriginalControlRect, Control control)
        {
            float xAxis = (float)(this.Width) / (float)(originalFormSize.Width);
            float yAxis = (float)(this.Height) / (float)(originalFormSize.Height);

            int newXPosition = (int)(OriginalControlRect.X * xAxis);
            int newYPosition = (int)(OriginalControlRect.Y * yAxis);

            int newWidth = (int)(OriginalControlRect.Width * xAxis);
            int newHeight = (int)(OriginalControlRect.Height * yAxis);

            control.Location = new Point(newXPosition, newYPosition);
            control.Size = new Size(newWidth, newHeight);
        }

        float num1, num2, result;
        char operation;
        bool dec = false;


        private void changeLabel(int numPressed)
        {
            if (dec == true)
            {
                int decimalCount = 0;
                foreach (char c in displayLabel.Text)
                {
                    if (c == '.')
                    {
                        decimalCount++;
                    }
                }
                if (decimalCount < 1)
                {
                    displayLabel.Text = displayLabel.Text + ".";
                }
                dec = false;
            }
            else
            {
                if ((displayLabel.Text.Equals("0") == true && displayLabel.Text != null))
                {
                    displayLabel.Text = numPressed.ToString();
                }
                else if (displayLabel.Text.Equals("-0") == true)
                {
                    displayLabel.Text = "-" + numPressed.ToString();
                }
                else
                {
                    displayLabel.Text = displayLabel.Text + numPressed.ToString();
                }
            }
        }
        private void oneButton_Click(object sender, EventArgs e)
        {
            changeLabel(1);
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            changeLabel(2);
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            changeLabel(3);
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            changeLabel(4);

        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            changeLabel(5);
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            changeLabel(6);
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            changeLabel(7);
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            changeLabel(8);
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            changeLabel(9);
        }


        private void DECButton_Click(object sender, EventArgs e)
        {
            string dec = displayLabel.Text.ToString();
            displayLabel.Text = ConvertToDec(dec).ToString();
        }

        private double ConvertToDec(string Bin)
        {
            double Dec = 0;
            var length = Bin.Length;
            for (int i = length - 1; i >= 0; i--)
            {
                if (Bin[length - 1 - i] == '1')
                {
                    Dec += Math.Pow(2, i);
                }
            }
            return Dec;
        }

        private void plusButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '+';
            result = result + num1;
            displayLabel.Text = "";
        }

        private void minusButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '-';
            displayLabel.Text = "";
        }

        private void divideButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '/';
            displayLabel.Text = "";
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            num1 = float.Parse(displayLabel.Text);
            operation = '*';
            displayLabel.Text = "";
        }

        private void equalButton_Click(object sender, EventArgs e)
        {
            result = 0;
            if (displayLabel.Text.Equals("0") == false)
            {
                switch (operation)
                {
                    case '+':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 + num2;
                        break;
                    case '-':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 - num2;
                        break;
                    case '/':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 / num2;
                        break;
                    case '*':
                        num2 = float.Parse(displayLabel.Text);
                        result = num1 * num2;
                        break;
                    default:
                        break;
                }
            }
            displayLabel.Text = result.ToString();
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            int stringLength = displayLabel.Text.Length;
            if (stringLength > 1)
            {
                displayLabel.Text = displayLabel.Text.Substring(0, stringLength - 1);
            }
            else
            {
                displayLabel.Text = "0";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            displayLabel.Text = "0";
            num1 = 0;
            num2 = 0;
            result = 0;
            operation = '\0';
            dec = false;
        }

        private void LOCButton_Click(object sender, EventArgs e)
        {
            double dec = double.Parse(displayLabel.Text);
            displayLabel.Text = CovertToLocation(dec);
            Reverse(displayLabel.Text);
            displayLabel.Text = Reverse(displayLabel.Text);

        }


        private string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        public string CovertToLocation(double Dec)
        {
            char[] letterArr = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            int maxPow = 0;
            string loc = "";
            while (Math.Pow(2, maxPow) < Dec)
            {
                maxPow++;
            }
            maxPow--;
            for (int i = maxPow; i >= 0; i--)
            {
                if (Math.Pow(2, i) <= Dec)
                {
                    loc += letterArr[i];
                    Dec = Dec - Math.Pow(2, i);
                }
            }
            return loc;
        }
      
        //void means no data or change or just console line, means empty




        private void ButtonZero_Click(object sender, EventArgs e)
        {
            changeLabel(0);
        }

        private void BINButton_Click(object sender, EventArgs e)
        {
            double dec = double.Parse(displayLabel.Text);
            displayLabel.Text = CovertToBinary(dec);
        }
        public string CovertToBinary(double Dec)
        {
            int maxPow = 0;
            string binary = "";
            while (Math.Pow(2, maxPow) < Dec)
            {
                maxPow++;
            }
            maxPow--;
            for (int i = maxPow; i >= 0; i--)
            {
                if (Math.Pow(2, i) <= Dec)
                {
                    binary += "1";
                    Dec = Dec - Math.Pow(2, i);
                }
                else
                {
                    binary += "0";
                }
            }
            return binary;
        }

        private void Calculator_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad0:
                    oneButton.PerformClick();
                    break;
                case Keys.D0:
                    ButtonZero.PerformClick();
                    break;
                case Keys.NumPad1:
                    oneButton.PerformClick();
                    break;
                case Keys.D1:
                    oneButton.PerformClick();
                    break;
                case Keys.NumPad2:
                    twoButton.PerformClick();
                    break;
                case Keys.D2:
                    twoButton.PerformClick();
                    break;
                case Keys.NumPad3:
                    threeButton.PerformClick();
                    break;
                case Keys.D3:
                    threeButton.PerformClick();
                    break;
                case Keys.NumPad4:
                    fourButton.PerformClick();
                    break;
                case Keys.D4:
                    fourButton.PerformClick();
                    break;
                case Keys.NumPad5:
                    fiveButton.PerformClick();
                    break;
                case Keys.D5:
                    fiveButton.PerformClick();
                    break;
                case Keys.NumPad6:
                    sixButton.PerformClick();
                    break;
                case Keys.D6:
                    sixButton.PerformClick();
                    break;
                case Keys.NumPad7:
                    sevenButton.PerformClick();
                    break;
                case Keys.D7:
                    sevenButton.PerformClick();
                    break;
                case Keys.NumPad8:
                    eightButton.PerformClick();
                    break;
                case Keys.D8:
                    eightButton.PerformClick();
                    break;
                case Keys.NumPad9:
                    nineButton.PerformClick();
                    break;
                case Keys.D9:
                    nineButton.PerformClick();
                    break;
                case Keys.Divide:
                    divideButton.PerformClick();
                    break;
                case Keys.Subtract:
                    minusButton.PerformClick();
                    break;
                case Keys.Add:
                    plusButton.PerformClick();
                    break;
                case Keys.Multiply:
                    multiplyButton.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void Calculator_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    equalButton.PerformClick();
                    break;
                default:
                    break;
            }
        }
    }
}