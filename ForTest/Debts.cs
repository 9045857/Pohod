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
    public class Debts
    {
        private int _xBetweenControls = 5;
        private int _xTextEditWidth = 50;
        private int _deltaY = 25;
        private int _currentY = 5;
        private int _positionX = 5;

        private Panel panel;

        public Debts(Panel panel)
        {
            this.panel = panel;
        }

        private void CreateUnit(Person person, int x, int y)
        {
            CheckBox checkBox = new CheckBox
            {
                Parent = panel,
                Name = string.Format("Person{0}", person.ID),
                Text = person.Name,
                Location = new Point(x, y),
                Checked = true
                
            };

            int checkBoxLenght = checkBox.Width;

            TextBox textBoxFactor = new TextBox
            {
                Parent = panel,
                Name = string.Format("PersonFactor{0}", person.ID),
                Text = "1",
                Location = new Point(x+checkBoxLenght+ _xBetweenControls , y),

                Width = _xTextEditWidth
            };

            TextBox textBoxMoney = new TextBox
            {
                Parent = panel,
                Name = string.Format("PersonPayment{0}", person.ID),
                Text = "",
                Location = new Point(x + checkBoxLenght + _xBetweenControls+ _xTextEditWidth+ _xBetweenControls, y),

                Width = _xTextEditWidth
            };
        }

        public void AddDebt(Person person)
        {
            CreateUnit(person, _positionX, _currentY);
            _currentY += _deltaY;
        }

        public void AddListDebt(List<Person> people)
        {
            foreach (Person person in people)
            {
                CreateUnit(person, _positionX, _currentY);
                _currentY += _deltaY;
            }
        }
    }
}
