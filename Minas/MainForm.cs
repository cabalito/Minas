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

using System.Diagnostics;
using System.Windows.Forms;

namespace Minas
{
	public partial class MainForm : Form
	{
		private Tablero tablero;
		//private int numColumns;
		
		private const string hightDifficulty = "Alta";
		private const string mediumDifficulty = "Media";
		private const string lowDifficulty = "Baja";
		
		private const string LARGE = "Grande";
		private const string MEDIUM = "Mediano";
		private const string SMALL = "Pequeño";
		
		private int numColumns;
		private int difficulty;
		
		public MainForm()
		{
			this.numColumns = 10;
			this.difficulty = 15;
			this.tablero = new Tablero(numColumns, numColumns, difficulty);
			InitializeComponent(numColumns);
			this.comboBoxDificultad.Items.Add(hightDifficulty);
			this.comboBoxDificultad.Items.Add(mediumDifficulty);
			this.comboBoxDificultad.Items.Add(lowDifficulty);
			
			this.comboBoxTamanio.Items.Add(LARGE);
			this.comboBoxTamanio.Items.Add(MEDIUM);
			this.comboBoxTamanio.Items.Add(SMALL);
			
			foreach (System.Windows.Forms.Button btn in buttons)
			{
			    btn.MouseDown  += (sender, args) => ButtonsClick(btn, sender, args);
			}
			comboBoxTamanio.SelectedIndexChanged += (sender, args) => ComboBoxTamanioSelectedIndexChanged();
			comboBoxDificultad.SelectedIndexChanged += (sender, args) => ComboBoxDificultadSelectedIndexChanged();
			tablero.updateTablero(buttons);
			
		}
		
		
		void ComboBoxDificultadSelectedIndexChanged()
		{
			string selectedItem = this.comboBoxDificultad.SelectedItem.ToString();
			switch (selectedItem)
            {
                case hightDifficulty:
					this.difficulty = 30;
                    break;
                case mediumDifficulty:
                    this.difficulty = 15;
                    break;
                case lowDifficulty:
                   this.difficulty = 7;
                   break;
			}
			this.tablero = new Tablero(numColumns, numColumns, difficulty);
			this.tablero.updateTablero(buttons);
			this.labelNumeroBombas.Text = "Numero de bombas: "+ tablero.getNumeroBombas(); 
		}
		
		
		void ComboBoxTamanioSelectedIndexChanged()
		{
			string selectedItem = this.comboBoxTamanio.SelectedItem.ToString();
			
			switch (selectedItem)
            {
                case LARGE:
					this.numColumns = 10;
                    break;
                case MEDIUM:
                    this.numColumns = 8;
                    break;
                case SMALL:
                   this.numColumns = 5;
                   break;
			}
			this.tablero = new Tablero(numColumns, numColumns, difficulty);
			UpdateComponent(numColumns);
			foreach (System.Windows.Forms.Button btn in buttons)
			{
			    btn.MouseDown  += (sender, args) => ButtonsClick(btn, sender, args);
			}
			this.tablero.updateTablero(buttons);
		}
		
		void ButtonsClick(System.Windows.Forms.Button btn, object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right){
				if(!tablero.ponerBandera(btn)){
					tablero.updateTablero(buttons);
					string message = "Has perdido ¿Deseas volver a jugar?";
                    string caption = "Loooooser!";
                    this.showOptionMessage(message, caption);
				}else if(tablero.getNumeroBombas() == 0){
					tablero.updateTablero(buttons);
					string message = "¡HAS GANADO! ¿Deseas volver a jugar?";
					string caption = " Winner!";
					this.showOptionMessage(message, caption);
				}
			}else{
				String name = btn.Name;
				int f = Int32.Parse( name.Substring(0, 2));
				int c = Int32.Parse(name.Substring(2,2));
				if(tablero.levanta(f, c)){
					tablero.updateTablero(buttons);
					string message = "Has perdido ¿Deseas volver a jugar?";
                    string caption = "Loooooser!";
                    this.showOptionMessage(message, caption);
				}
			}
			tablero.updateTablero(buttons);
			this.labelNumeroBombas.Text = "Numero de bombas: "+ tablero.getNumeroBombas();
		}
		
		private void showOptionMessage(string message, string caption){
			MessageBoxButtons options = MessageBoxButtons.YesNo;
					DialogResult result;
					result = MessageBox.Show(message, caption, options);
					if (result == System.Windows.Forms.DialogResult.Yes){
						this.tablero = new Tablero(numColumns, numColumns, difficulty);
						tablero.updateTablero(buttons);
					}else{
						//this.Close();
					}
		}
	}
}
