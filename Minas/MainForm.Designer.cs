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
		private int maxSize = 284;
		private int buttonSize = 20;
		private System.Windows.Forms.Button[] buttons;
		
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
			if(widthLateral<maxSize){
				maxSize = widthLateral;
			}
			numColumns = (maxSize/20);
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
			this.groupBox1.Size = new System.Drawing.Size(maxSize+20, maxSize+20);
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
				btn.Name = f.ToString() + c;
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
			this.Name = "MainForm";
			this.Text = "Minas";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
