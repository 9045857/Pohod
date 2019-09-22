using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Pohod
{
	public class Page1 : ContentPage
	{
		public Page1 ()
		{
			Content = new StackLayout {
				Children = {
					new Label { Text = "УХУ Welcome to Xamarin.Forms!" }
				}
			};
		}
	}
}