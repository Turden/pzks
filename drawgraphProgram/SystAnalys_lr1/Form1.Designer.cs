namespace SystAnalys_lr1
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBoxMatrix = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalgorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.алгоритмыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algo2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algo7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algo14ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkgrafToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.drawEdgeButton = new System.Windows.Forms.Button();
            this.drawVertexButton = new System.Windows.Forms.Button();
            this.sheet = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxMatrix
            // 
            this.listBoxMatrix.FormattingEnabled = true;
            this.listBoxMatrix.Location = new System.Drawing.Point(683, 26);
            this.listBoxMatrix.Name = "listBoxMatrix";
            this.listBoxMatrix.Size = new System.Drawing.Size(274, 394);
            this.listBoxMatrix.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(969, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewToolStripMenuItem,
            this.SaveToolStripMenuItem,
            this.OpenToolStripMenuItem,
            this.InfoToolStripMenuItem,
            this.generalgorToolStripMenuItem,
            this.алгоритмыToolStripMenuItem,
            this.checkgrafToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // NewToolStripMenuItem
            // 
            this.NewToolStripMenuItem.Name = "NewToolStripMenuItem";
            this.NewToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.NewToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.NewToolStripMenuItem.Text = "Новый";
            this.NewToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItem_Click);
            // 
            // SaveToolStripMenuItem
            // 
            this.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            this.SaveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.SaveToolStripMenuItem.Text = "Сохранить";
            this.SaveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // OpenToolStripMenuItem
            // 
            this.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            this.OpenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.OpenToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.OpenToolStripMenuItem.Text = "Загрузить";
            this.OpenToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.InfoToolStripMenuItem.Text = "Инфо";
            this.InfoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // generalgorToolStripMenuItem
            // 
            this.generalgorToolStripMenuItem.Name = "generalgorToolStripMenuItem";
            this.generalgorToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.generalgorToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.generalgorToolStripMenuItem.Text = "Генерация алгоритма";
            this.generalgorToolStripMenuItem.Click += new System.EventHandler(this.generalgorToolStripMenuItem_Click);
            // 
            // алгоритмыToolStripMenuItem
            // 
            this.алгоритмыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algo2ToolStripMenuItem,
            this.algo7ToolStripMenuItem,
            this.algo14ToolStripMenuItem});
            this.алгоритмыToolStripMenuItem.Name = "алгоритмыToolStripMenuItem";
            this.алгоритмыToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.алгоритмыToolStripMenuItem.Text = "Алгоритмы";
            // 
            // algo2ToolStripMenuItem
            // 
            this.algo2ToolStripMenuItem.Name = "algo2ToolStripMenuItem";
            this.algo2ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.algo2ToolStripMenuItem.Text = "Алгоритм 2";
            this.algo2ToolStripMenuItem.Click += new System.EventHandler(this.algo2ToolStripMenuItem_Click);
            // 
            // algo7ToolStripMenuItem
            // 
            this.algo7ToolStripMenuItem.Name = "algo7ToolStripMenuItem";
            this.algo7ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.algo7ToolStripMenuItem.Text = "Алгоритм 7";
            this.algo7ToolStripMenuItem.Click += new System.EventHandler(this.algo7ToolStripMenuItem_Click);
            // 
            // algo14ToolStripMenuItem
            // 
            this.algo14ToolStripMenuItem.Name = "algo14ToolStripMenuItem";
            this.algo14ToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.algo14ToolStripMenuItem.Text = "Алгоритм 14";
            this.algo14ToolStripMenuItem.Click += new System.EventHandler(this.algo14ToolStripMenuItem_Click);
            // 
            // checkgrafToolStripMenuItem
            // 
            this.checkgrafToolStripMenuItem.Name = "checkgrafToolStripMenuItem";
            this.checkgrafToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.checkgrafToolStripMenuItem.Text = "Проверка графа";
            this.checkgrafToolStripMenuItem.Click += new System.EventHandler(this.checkgrafToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // selectButton
            // 
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.Location = new System.Drawing.Point(12, 39);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(45, 45);
            this.selectButton.TabIndex = 9;
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(13, 210);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(45, 45);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // drawEdgeButton
            // 
            this.drawEdgeButton.Image = ((System.Drawing.Image)(resources.GetObject("drawEdgeButton.Image")));
            this.drawEdgeButton.Location = new System.Drawing.Point(13, 159);
            this.drawEdgeButton.Name = "drawEdgeButton";
            this.drawEdgeButton.Size = new System.Drawing.Size(45, 45);
            this.drawEdgeButton.TabIndex = 2;
            this.drawEdgeButton.UseVisualStyleBackColor = true;
            this.drawEdgeButton.Click += new System.EventHandler(this.drawEdgeButton_Click);
            // 
            // drawVertexButton
            // 
            this.drawVertexButton.Image = ((System.Drawing.Image)(resources.GetObject("drawVertexButton.Image")));
            this.drawVertexButton.Location = new System.Drawing.Point(13, 97);
            this.drawVertexButton.Name = "drawVertexButton";
            this.drawVertexButton.Size = new System.Drawing.Size(45, 45);
            this.drawVertexButton.TabIndex = 1;
            this.drawVertexButton.UseVisualStyleBackColor = true;
            this.drawVertexButton.Click += new System.EventHandler(this.drawVertexButton_Click);
            // 
            // sheet
            // 
            this.sheet.BackColor = System.Drawing.SystemColors.Control;
            this.sheet.Location = new System.Drawing.Point(77, 27);
            this.sheet.Name = "sheet";
            this.sheet.Size = new System.Drawing.Size(600, 400);
            this.sheet.TabIndex = 0;
            this.sheet.TabStop = false;
            this.sheet.MouseClick += new System.Windows.Forms.MouseEventHandler(this.sheet_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 444);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.listBoxMatrix);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.drawEdgeButton);
            this.Controls.Add(this.drawVertexButton);
            this.Controls.Add(this.sheet);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Tarkovskiy";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sheet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox sheet;
        private System.Windows.Forms.Button drawVertexButton;
        private System.Windows.Forms.Button drawEdgeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.ListBox listBoxMatrix;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem NewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem алгоритмыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algo2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algo7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algo14ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generalgorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkgrafToolStripMenuItem;
    }
}

