using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CostSharing;

namespace ForTest
{
    public class Debt
    {
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

        public Debt(Panel panel, Person person)
        {
            this.panel = panel;
            this.Person = person;
        }

        public Debt(Panel panel, Person person, int debtNumber)
        {
            this.panel = panel;
            this.Person = person;

            CreateUnit(debtNumber);
        }

        public void CreateUnit(int debtNumber)
        {
            _y = _height * debtNumber;

            CheckBox = new CheckBox
            {
                Parent = panel,
                Text = Person.Name,
                Location = new Point(_positionX, _y),
                Checked = true
            };

            int checkBoxLenght = CheckBox.Width;

            TextBoxFactor = new TextBox
            {
                Parent = panel,
                Text = Person.DebtFactor.ToString(),
                Location = new Point(_positionX + checkBoxLenght, _y),

                Width = _xTextEditWidth
            };

            TextBoxDebt = new TextBox
            {
                Parent = panel,
                Text = "",
                Location = new Point(_positionX + checkBoxLenght + _xBetweenControls + _xTextEditWidth, _y),

                Width = _xTextEditWidth
            };

            TextBoxPayment = new TextBox
            {
                Parent = panel,
                Text = "",
                Location = new Point(_positionX + checkBoxLenght + 2 * _xBetweenControls + 2 * _xTextEditWidth, _y),

                Width = _xTextEditWidth
            };
        }

        public override string ToString()
        {
            string name = string.IsNullOrEmpty(Person.Name) ? "NonamePerson" : Person.Name;

            if (Equals(Person.PayGroupLeader, Person))
            {
                return name;
            }
            else
            {
                return "  " + name;
            }
        }
    }
}
