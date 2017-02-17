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

using System.Windows.Forms;

namespace Minas
{
	public partial class MainForm : Form
	{
		private Tablero tablero;
		private int numColumns;
		
		public MainForm(int numColumns)
		{
			this.tablero = new Tablero(numColumns, numColumns);
			this.numColumns = numColumns;
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
				if(!tablero.ponerBandera(btn)){
					MessageBoxButtons options = MessageBoxButtons.YesNo;
					string message = "Has perdido ¿Deseas volver a jugar?";
                    string caption = "Loooooser!";
					DialogResult result;
					result = MessageBox.Show(message, caption, options);
					if (result == System.Windows.Forms.DialogResult.Yes){
						this.tablero = new Tablero(numColumns, numColumns);
						tablero.updateTablero(buttons);
					}else{
						//this.Close();
					}
				}
				this.labelNumeroBombas.Text = "Numero de bombas: "+ tablero.getNumeroBombas();
			}else{
				String name = btn.Name;
				int f = Int32.Parse( name.Substring(0, 1));
				int c = Int32.Parse(name.Substring(1,1));
				tablero.levanta(f, c);
				tablero.updateTablero(buttons);
			}
		}
	}
}
