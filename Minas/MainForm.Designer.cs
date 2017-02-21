/*
 * Created by SharpDevelop.
 * User: jmolinma
 * Date: 15/02/2017
 * Time: 17:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace Minas
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBox1;
		private int buttonSize = 20;
		private System.Windows.Forms.Label labelNumeroBombas;
		private System.Windows.Forms.Button[] buttons;
		private System.Windows.Forms.ComboBox comboBoxDificultad;
		private System.Windows.Forms.ComboBox comboBoxTamanio;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent(int numColumns)
		{
			int widthLateral = numColumns*buttonSize;
			numColumns = (widthLateral/buttonSize);
			int totalButtonNumber = numColumns * numColumns;
			this.comboBoxDificultad = new System.Windows.Forms.ComboBox();
			this.comboBoxTamanio = new System.Windows.Forms.ComboBox();

			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttons = new System.Windows.Forms.Button[totalButtonNumber];
			for(int i=0; i<totalButtonNumber; i++){
				this.buttons[i] = new System.Windows.Forms.Button();
			}
			this.groupBox1.SuspendLayout();
			this.labelNumeroBombas = new System.Windows.Forms.Label();
			this.SuspendLayout();
			
			
			// 
			// labelNumeroBombas
			// 
			this.labelNumeroBombas.Location = new System.Drawing.Point(widthLateral + 50, 50);
			this.labelNumeroBombas.Name = "labelNumeroBombas";
			this.labelNumeroBombas.Size = new System.Drawing.Size(150, 23);
			this.labelNumeroBombas.TabIndex = 0;
			this.labelNumeroBombas.Text = "Numero de bombas: "+ tablero.getNumeroBombas();
			// 
			// groupBox1
			// 
			foreach (System.Windows.Forms.Button btn in buttons){
				this.groupBox1.Controls.Add(btn);
			}
			this.groupBox1.Location = new System.Drawing.Point(12, 42);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(widthLateral+20, widthLateral+20);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// buttons
			//
			int f=0; int c=1;
			foreach (System.Windows.Forms.Button btn in buttons){
				
				if(f < numColumns){
					f++;
				}else{
					f=1;
					c++;
				}
				
				btn.Location = new System.Drawing.Point(buttonSize*f, buttonSize*c);
				btn.Name = c.ToString("D2") + f.ToString("D2");
				btn.Size = new System.Drawing.Size(buttonSize, buttonSize);
				btn.TabIndex = 0;
				btn.Text = f.ToString()+ c;
				btn.UseVisualStyleBackColor = true;
			}
			
			// 
			// comboBoxDificultad
			// 
			this.comboBoxDificultad.FormattingEnabled = true;
			this.comboBoxDificultad.Location = new System.Drawing.Point(widthLateral + 50, 70);
			this.comboBoxDificultad.Name = "comboBoxDificultad";
			this.comboBoxDificultad.Size = new System.Drawing.Size(121, 30);
			this.comboBoxDificultad.TabIndex = 1;
			this.comboBoxDificultad.Text = "Dificultad";
			this.comboBoxDificultad.Items.Add(HIGHT_DIFFICULTY);
			this.comboBoxDificultad.Items.Add(MEDIUM_DIFFICULTY);
			this.comboBoxDificultad.Items.Add(LOW_DIFFICULTY);

			
			// 
			// comboBoxTamanio
			// 
			this.comboBoxTamanio.FormattingEnabled = true;
			this.comboBoxTamanio.Location = new System.Drawing.Point(widthLateral + 50, 90);
			this.comboBoxTamanio.Name = "comboBoxTamanio";
			this.comboBoxTamanio.Size = new System.Drawing.Size(121, 30);
			this.comboBoxTamanio.TabIndex = 1;
			this.comboBoxTamanio.Text = "Tamaño";
			this.comboBoxTamanio.Items.Add(LARGE_SIZE);
			this.comboBoxTamanio.Items.Add(MEDIUM_SIZE);
			this.comboBoxTamanio.Items.Add(SMALL_SIZE);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 400);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.labelNumeroBombas);
			this.Controls.Add(this.comboBoxDificultad);
			this.Controls.Add(this.comboBoxTamanio);
			this.Name = "MainForm";
			this.Text = "Minas";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		
		private void UpdateComponent(int numColumns)
		{
			
			this.Controls.Remove(groupBox1);
			
			int widthLateral = numColumns*buttonSize;
			numColumns = (widthLateral/buttonSize);
			int totalButtonNumber = numColumns * numColumns;
			
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.buttons = new System.Windows.Forms.Button[totalButtonNumber];
			for(int i=0; i<totalButtonNumber; i++){
				this.buttons[i] = new System.Windows.Forms.Button();
			}
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			
			//
			// groupBox1
			// 
			foreach (System.Windows.Forms.Button btn in buttons){
				this.groupBox1.Controls.Add(btn);
			}
			this.groupBox1.Location = new System.Drawing.Point(12, 42);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(widthLateral+20, widthLateral+20);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// button1
			//
			int f=0; int c=1;
			foreach (System.Windows.Forms.Button btn in buttons){
				
				if(f < numColumns){
					f++;
				}else{
					f=1;
					c++;
				}
				
				btn.Location = new System.Drawing.Point(buttonSize*f, buttonSize*c);
				btn.Name = c.ToString("D2") + f.ToString("D2");
				btn.Size = new System.Drawing.Size(buttonSize, buttonSize);
				btn.TabIndex = 0;
				btn.Text = f.ToString()+ c;
				btn.UseVisualStyleBackColor = true;
			}
			
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 400);
			this.Controls.Add(this.groupBox1);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		
		void AddListeners()
		{
			foreach (System.Windows.Forms.Button btn in buttons)
			{
			    btn.MouseDown  += (sender, args) => ButtonsClick(btn, sender, args);
			}
			comboBoxTamanio.SelectedIndexChanged += (sender, args) => ComboBoxesSelectedIndexChanged(comboBoxTamanio);
			comboBoxDificultad.SelectedIndexChanged += (sender, args) => ComboBoxesSelectedIndexChanged(comboBoxDificultad);
		}
	}
}
