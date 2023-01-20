namespace Remont
{
    partial class Masterskay
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.vvod = new System.Windows.Forms.ToolStripMenuItem();
            this.sotr = new System.Windows.Forms.ToolStripMenuItem();
            this.price = new System.Windows.Forms.ToolStripMenuItem();
            this.remont = new System.Windows.Forms.ToolStripMenuItem();
            this.spravochniki = new System.Windows.Forms.ToolStripMenuItem();
            this.avto = new System.Windows.Forms.ToolStripMenuItem();
            this.otcheti = new System.Windows.Forms.ToolStripMenuItem();
            this.spisok_sotr = new System.Windows.Forms.ToolStripMenuItem();
            this.vipolnenie = new System.Windows.Forms.ToolStripMenuItem();
            this.reiting = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vvod,
            this.remont,
            this.spravochniki,
            this.otcheti,
            this.Exit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // vvod
            // 
            this.vvod.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sotr,
            this.price});
            this.vvod.Name = "vvod";
            this.vvod.Size = new System.Drawing.Size(48, 20);
            this.vvod.Text = "Ввод";
            // 
            // sotr
            // 
            this.sotr.Name = "sotr";
            this.sotr.Size = new System.Drawing.Size(180, 22);
            this.sotr.Text = "Мастера";
            this.sotr.Click += new System.EventHandler(this.sotrToolStripMenuItem_Click);
            // 
            // price
            // 
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(180, 22);
            this.price.Text = "Прайс-лист услуг";
            this.price.Click += new System.EventHandler(this.price_Click);
            // 
            // remont
            // 
            this.remont.Name = "remont";
            this.remont.Size = new System.Drawing.Size(61, 20);
            this.remont.Text = "Ремонт";
            this.remont.Click += new System.EventHandler(this.remont_Click);
            // 
            // spravochniki
            // 
            this.spravochniki.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.avto});
            this.spravochniki.Name = "spravochniki";
            this.spravochniki.Size = new System.Drawing.Size(97, 20);
            this.spravochniki.Text = "Справочники";
            // 
            // avto
            // 
            this.avto.Name = "avto";
            this.avto.Size = new System.Drawing.Size(147, 22);
            this.avto.Text = "Автомобили";
            this.avto.Click += new System.EventHandler(this.avto_Click);
            // 
            // otcheti
            // 
            this.otcheti.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spisok_sotr,
            this.vipolnenie,
            this.reiting});
            this.otcheti.Name = "otcheti";
            this.otcheti.Size = new System.Drawing.Size(62, 20);
            this.otcheti.Text = "Отчеты";
            // 
            // spisok_sotr
            // 
            this.spisok_sotr.Name = "spisok_sotr";
            this.spisok_sotr.Size = new System.Drawing.Size(243, 22);
            this.spisok_sotr.Text = "Список сотрудников";
            this.spisok_sotr.Click += new System.EventHandler(this.spisok_sotr_Click);
            // 
            // vipolnenie
            // 
            this.vipolnenie.Name = "vipolnenie";
            this.vipolnenie.Size = new System.Drawing.Size(243, 22);
            this.vipolnenie.Text = "Выполнение услуг за период";
            this.vipolnenie.Click += new System.EventHandler(this.vipolnenie_Click);
            // 
            // reiting
            // 
            this.reiting.Name = "reiting";
            this.reiting.Size = new System.Drawing.Size(243, 22);
            this.reiting.Text = "Рейтинг услуг";
            this.reiting.Click += new System.EventHandler(this.reiting_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(58, 20);
            this.Exit.Text = "Выход";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Masterskay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Masterskay";
            this.Text = "Автомастерская";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem vvod;
        private System.Windows.Forms.ToolStripMenuItem sotr;
        private System.Windows.Forms.ToolStripMenuItem price;
        private System.Windows.Forms.ToolStripMenuItem remont;
        private System.Windows.Forms.ToolStripMenuItem spravochniki;
        private System.Windows.Forms.ToolStripMenuItem avto;
        private System.Windows.Forms.ToolStripMenuItem otcheti;
        private System.Windows.Forms.ToolStripMenuItem spisok_sotr;
        private System.Windows.Forms.ToolStripMenuItem vipolnenie;
        private System.Windows.Forms.ToolStripMenuItem reiting;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.Label label1;
    }
}

