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
    class Debt
    {
        public Person Person { get; set; }

        public CheckBox CheckBox { get; set; }
        public TextBox TextBoxFactor { get; set; }
        public TextBox TextBoxMoney { get; set; }

        private int _xBetweenControls = 5;
        private int _xTextEditWidth = 50;
        private int _positionX = 5;

        private int _y;
        private readonly int _height=20;

        private Panel panel;

        public Debt(Panel panel, Person person,int debtNumber)
        {
            this.panel = panel;
            this.Person = person;
            this._y = _height*debtNumber;

            CreateUnit();
        }

        private void CreateUnit()
        {
            CheckBox = new CheckBox
            {
                Parent = panel,
              //  Name = string.Format("Person{0}", person.ID),
                Text = Person.Name,
                Location = new Point(_positionX, _y),
                Checked = true
            };

            int checkBoxLenght = CheckBox.Width;

             TextBoxFactor = new TextBox
            {
                Parent = panel,
              //  Name = string.Format("PersonFactor{0}", person.ID),
                Text = "1",
                Location = new Point(_positionX + checkBoxLenght + _xBetweenControls, _y),

                Width = _xTextEditWidth
            };

             TextBoxMoney = new TextBox
            {
                Parent = panel,
                //Name = string.Format("PersonPayment{0}", person.ID),
                Text = "",
                Location = new Point(_positionX + checkBoxLenght + _xBetweenControls + _xTextEditWidth + _xBetweenControls, _y),

                Width = _xTextEditWidth
            };
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(Person.Name) ? "NonamePerson" : Person.Name;
        }
    }
}
