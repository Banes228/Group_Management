namespace Group_Management
{
    partial class ChoiсeGroupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.choiceListBox = new System.Windows.Forms.ListBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.confirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // choiceListBox
            // 
            this.choiceListBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.choiceListBox.FormattingEnabled = true;
            this.choiceListBox.ItemHeight = 23;
            this.choiceListBox.Location = new System.Drawing.Point(12, 12);
            this.choiceListBox.Name = "choiceListBox";
            this.choiceListBox.Size = new System.Drawing.Size(515, 165);
            this.choiceListBox.TabIndex = 3;
            this.choiceListBox.SelectedIndexChanged += new System.EventHandler(this.ChoiceListBox_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancelButton.Location = new System.Drawing.Point(327, 206);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(200, 45);
            this.cancelButton.TabIndex = 13;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // confirmButton
            // 
            this.confirmButton.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmButton.Location = new System.Drawing.Point(12, 206);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(200, 45);
            this.confirmButton.TabIndex = 12;
            this.confirmButton.Text = "Подтвердить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // ChoiсeGroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 264);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.choiceListBox);
            this.MaximumSize = new System.Drawing.Size(552, 303);
            this.MinimumSize = new System.Drawing.Size(552, 303);
            this.Name = "ChoiсeGroupForm";
            this.Text = "ChoiсeGroupForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.ChoiсeGroupForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox choiceListBox;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button confirmButton;
    }
}