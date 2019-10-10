using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CostSharing;

namespace ForTest
{
    public class PersonOnPanel
    {
        public int ID { get; set; }
        public Person Person { get; set; }

        public CheckBox CheckBox { get; set; }
        public TextBox TextBoxFactor { get; set; }
        public TextBox TextBoxDebt { get; set; }
        public TextBox TextBoxPayment { get; set; }

        private int _xBetweenControls = 5;
        private int _xTextEditWidth = 30;
        private int _positionX = 5;

        private int _y;
        private readonly int _height = 20;

        private Panel panel;

        public PersonOnPanel(Panel panel, int debtNumber)
        {
            this.panel = panel;
            CreateUnit(debtNumber);
        }

        public bool Visible
        {
            get
            {
                return CheckBox.Visible;
            }
            set
            {
                CheckBox.Visible = value;
                TextBoxFactor.Visible = value;
                TextBoxDebt.Visible = value;
                TextBoxPayment.Visible = value;
            }
        }

        public void LoadDebtData(Person person)
        {
            CheckBox.Checked = true;
            CheckBox.Text = person.Name;
            TextBoxFactor.Text = person.DebtFactor.ToString();
            TextBoxDebt.Text = "";
            TextBoxPayment.Text = "";

            Visible = true;
        }

        public void CreateUnit(int debtNumber)
        {
            _y = _height * debtNumber;

            CheckBox = new CheckBox
            {
                Parent = panel,
                Location = new Point(_positionX, _y),
                Checked = false,
                Visible = false
            };

            int checkBoxLenght = CheckBox.Width;

            TextBoxFactor = new TextBox
            {
                Parent = panel,
                Location = new Point(_positionX + checkBoxLenght, _y),
                Width = _xTextEditWidth,
                Visible = false
            };

            TextBoxDebt = new TextBox
            {
                Parent = panel,
                Location = new Point(_positionX + checkBoxLenght + _xBetweenControls + _xTextEditWidth, _y),
                Width = _xTextEditWidth,
                Visible = false
            };

            TextBoxPayment = new TextBox
            {
                Parent = panel,
                Location = new Point(_positionX + checkBoxLenght + 2 * _xBetweenControls + 2 * _xTextEditWidth, _y),
                Width = _xTextEditWidth,
                Visible = false
            };
        }

    }
}
