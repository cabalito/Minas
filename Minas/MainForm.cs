/*
 * Created by SharpDevelop.
 * User: jmolinma
 * Date: 15/02/2017
 * Time: 17:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Minas
{
	public partial class MainForm : Form
	{
		private Tablero tablero;
		
		public MainForm(int numColumns)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			tablero = new Tablero(numColumns, numColumns);
			InitializeComponent(numColumns);
			foreach (System.Windows.Forms.Button btn in buttons)
			{
			    btn.MouseDown  += (sender, args) => ButtonsClick(btn, sender, args);
			}
			
			tablero.updateTablero(buttons);
		}
		void ButtonsClick(System.Windows.Forms.Button btn, object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right){
				btn.BackColor = Color.Red;
				btn.Enabled = false;
			}else{
				String name = btn.Name;
				int f = Int32.Parse( name.Substring(0, 1));
				int c = Int32.Parse(name.Substring(1,1));
				tablero.levanta(c, f);
				tablero.updateTablero(buttons);
			}
		}
	}
}
