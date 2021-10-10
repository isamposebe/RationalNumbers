
namespace RationalsWinForms
{
    partial class Rationals
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstRational = new System.Windows.Forms.TextBox();
            this.secondRational = new System.Windows.Forms.TextBox();
            this.plus = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.minus = new System.Windows.Forms.RadioButton();
            this.multiply = new System.Windows.Forms.RadioButton();
            this.divide = new System.Windows.Forms.RadioButton();
            this.result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.evaluate = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // firstRational
            // 
            this.firstRational.Location = new System.Drawing.Point(83, 223);
            this.firstRational.Name = "firstRational";
            this.firstRational.Size = new System.Drawing.Size(150, 31);
            this.firstRational.TabIndex = 0;
            this.firstRational.TextChanged += new System.EventHandler(this.firstRational_TextChanged);
            // 
            // secondRational
            // 
            this.secondRational.Location = new System.Drawing.Point(311, 223);
            this.secondRational.Name = "secondRational";
            this.secondRational.Size = new System.Drawing.Size(150, 31);
            this.secondRational.TabIndex = 1;
            this.secondRational.TextChanged += new System.EventHandler(this.secondRational_TextChanged);
            // 
            // plus
            // 
            this.plus.AutoSize = true;
            this.plus.Location = new System.Drawing.Point(3, 3);
            this.plus.Name = "plus";
            this.plus.Size = new System.Drawing.Size(49, 29);
            this.plus.TabIndex = 3;
            this.plus.TabStop = true;
            this.plus.Text = "+";
            this.plus.UseVisualStyleBackColor = true;
            this.plus.CheckedChanged += new System.EventHandler(this.plus_CheckedChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.plus);
            this.flowLayoutPanel1.Controls.Add(this.minus);
            this.flowLayoutPanel1.Controls.Add(this.multiply);
            this.flowLayoutPanel1.Controls.Add(this.divide);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(239, 170);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(66, 150);
            this.flowLayoutPanel1.TabIndex = 4;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // minus
            // 
            this.minus.AutoSize = true;
            this.minus.Location = new System.Drawing.Point(3, 38);
            this.minus.Name = "minus";
            this.minus.Size = new System.Drawing.Size(44, 29);
            this.minus.TabIndex = 4;
            this.minus.TabStop = true;
            this.minus.Text = "-";
            this.minus.UseVisualStyleBackColor = true;
            this.minus.CheckedChanged += new System.EventHandler(this.minus_CheckedChanged);
            // 
            // multiply
            // 
            this.multiply.AutoSize = true;
            this.multiply.Location = new System.Drawing.Point(3, 73);
            this.multiply.Name = "multiply";
            this.multiply.Size = new System.Drawing.Size(45, 29);
            this.multiply.TabIndex = 5;
            this.multiply.TabStop = true;
            this.multiply.Text = "*";
            this.multiply.UseVisualStyleBackColor = true;
            this.multiply.CheckedChanged += new System.EventHandler(this.multiply_CheckedChanged);
            // 
            // divide
            // 
            this.divide.AutoSize = true;
            this.divide.Location = new System.Drawing.Point(3, 108);
            this.divide.Name = "divide";
            this.divide.Size = new System.Drawing.Size(44, 29);
            this.divide.TabIndex = 6;
            this.divide.TabStop = true;
            this.divide.Text = "/";
            this.divide.UseVisualStyleBackColor = true;
            this.divide.CheckedChanged += new System.EventHandler(this.divide_CheckedChanged);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(497, 226);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(150, 31);
            this.result.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(467, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "=";
            // 
            // evaluate
            // 
            this.evaluate.Location = new System.Drawing.Point(424, 263);
            this.evaluate.Name = "evaluate";
            this.evaluate.Size = new System.Drawing.Size(112, 34);
            this.evaluate.TabIndex = 7;
            this.evaluate.Text = "Calculate";
            this.evaluate.UseVisualStyleBackColor = true;
            this.evaluate.Click += new System.EventHandler(this.evaluate_Click);
            // 
            // Rationals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.evaluate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.result);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.secondRational);
            this.Controls.Add(this.firstRational);
            this.Name = "Rationals";
            this.Text = "Rationals";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox firstRational;
        private System.Windows.Forms.TextBox secondRational;
        private System.Windows.Forms.RadioButton plus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton minus;
        private System.Windows.Forms.RadioButton multiply;
        private System.Windows.Forms.RadioButton divide;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button evaluate;
    }
}

