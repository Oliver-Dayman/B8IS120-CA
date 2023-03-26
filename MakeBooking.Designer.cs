﻿
namespace TravelAgent
{
    partial class MakeBooking
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
            this.btnSearchFlights = new System.Windows.Forms.Button();
            this.dgvFlights = new System.Windows.Forms.DataGridView();
            this.lblDepDate = new System.Windows.Forms.Label();
            this.dtDeparture = new System.Windows.Forms.DateTimePicker();
            this.lblRetDate = new System.Windows.Forms.Label();
            this.dtReturn = new System.Windows.Forms.DateTimePicker();
            this.dgvReturns = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlBookingDetails = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlBookingHeader = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.txtCardNo = new System.Windows.Forms.TextBox();
            this.txtExpiry = new System.Windows.Forms.TextBox();
            this.txtCVV = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturns)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlBookingDetails.SuspendLayout();
            this.pnlBookingHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearchFlights
            // 
            this.btnSearchFlights.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSearchFlights.Location = new System.Drawing.Point(1021, 54);
            this.btnSearchFlights.Name = "btnSearchFlights";
            this.btnSearchFlights.Size = new System.Drawing.Size(159, 33);
            this.btnSearchFlights.TabIndex = 0;
            this.btnSearchFlights.Text = "Search Flights";
            this.btnSearchFlights.UseVisualStyleBackColor = false;
            this.btnSearchFlights.Click += new System.EventHandler(this.btnSearchFlights_Click);
            // 
            // dgvFlights
            // 
            this.dgvFlights.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFlights.Location = new System.Drawing.Point(98, 150);
            this.dgvFlights.Name = "dgvFlights";
            this.dgvFlights.RowHeadersWidth = 62;
            this.dgvFlights.RowTemplate.Height = 33;
            this.dgvFlights.Size = new System.Drawing.Size(1082, 225);
            this.dgvFlights.TabIndex = 2;
            // 
            // lblDepDate
            // 
            this.lblDepDate.AutoSize = true;
            this.lblDepDate.Location = new System.Drawing.Point(97, 60);
            this.lblDepDate.Name = "lblDepDate";
            this.lblDepDate.Size = new System.Drawing.Size(137, 25);
            this.lblDepDate.TabIndex = 3;
            this.lblDepDate.Text = "Departure Date:";
            // 
            // dtDeparture
            // 
            this.dtDeparture.Location = new System.Drawing.Point(240, 56);
            this.dtDeparture.Name = "dtDeparture";
            this.dtDeparture.Size = new System.Drawing.Size(316, 31);
            this.dtDeparture.TabIndex = 4;
            // 
            // lblRetDate
            // 
            this.lblRetDate.AutoSize = true;
            this.lblRetDate.Location = new System.Drawing.Point(577, 60);
            this.lblRetDate.Name = "lblRetDate";
            this.lblRetDate.Size = new System.Drawing.Size(109, 25);
            this.lblRetDate.TabIndex = 5;
            this.lblRetDate.Text = "Return Date:";
            // 
            // dtReturn
            // 
            this.dtReturn.Location = new System.Drawing.Point(692, 55);
            this.dtReturn.Name = "dtReturn";
            this.dtReturn.Size = new System.Drawing.Size(315, 31);
            this.dtReturn.TabIndex = 6;
            // 
            // dgvReturns
            // 
            this.dgvReturns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturns.Location = new System.Drawing.Point(98, 439);
            this.dgvReturns.Name = "dgvReturns";
            this.dgvReturns.RowHeadersWidth = 62;
            this.dgvReturns.RowTemplate.Height = 33;
            this.dgvReturns.Size = new System.Drawing.Size(1082, 242);
            this.dgvReturns.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(96, 117);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1084, 33);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(504, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Departures";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(96, 405);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1084, 33);
            this.panel2.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(493, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Return Flights";
            // 
            // pnlBookingDetails
            // 
            this.pnlBookingDetails.Controls.Add(this.txtName);
            this.pnlBookingDetails.Controls.Add(this.txtCVV);
            this.pnlBookingDetails.Controls.Add(this.txtExpiry);
            this.pnlBookingDetails.Controls.Add(this.txtCardNo);
            this.pnlBookingDetails.Controls.Add(this.btnPay);
            this.pnlBookingDetails.Controls.Add(this.label8);
            this.pnlBookingDetails.Controls.Add(this.label7);
            this.pnlBookingDetails.Controls.Add(this.label6);
            this.pnlBookingDetails.Controls.Add(this.label5);
            this.pnlBookingDetails.Controls.Add(this.txtPrice);
            this.pnlBookingDetails.Controls.Add(this.label3);
            this.pnlBookingDetails.Location = new System.Drawing.Point(1223, 150);
            this.pnlBookingDetails.Name = "pnlBookingDetails";
            this.pnlBookingDetails.Size = new System.Drawing.Size(593, 530);
            this.pnlBookingDetails.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Expiry:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 25);
            this.label5.TabIndex = 12;
            this.label5.Text = "Card No:";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(150, 67);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.ReadOnly = true;
            this.txtPrice.Size = new System.Drawing.Size(150, 31);
            this.txtPrice.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Price:";
            // 
            // pnlBookingHeader
            // 
            this.pnlBookingHeader.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pnlBookingHeader.Controls.Add(this.label4);
            this.pnlBookingHeader.Location = new System.Drawing.Point(1223, 117);
            this.pnlBookingHeader.Name = "pnlBookingHeader";
            this.pnlBookingHeader.Size = new System.Drawing.Size(593, 33);
            this.pnlBookingHeader.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(222, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Booking Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(306, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "CVV No:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 303);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 25);
            this.label8.TabIndex = 15;
            this.label8.Text = "Name:";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(148, 390);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(152, 34);
            this.btnPay.TabIndex = 16;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = true;
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(150, 176);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Size = new System.Drawing.Size(348, 31);
            this.txtCardNo.TabIndex = 17;
            // 
            // txtExpiry
            // 
            this.txtExpiry.Location = new System.Drawing.Point(150, 235);
            this.txtExpiry.Name = "txtExpiry";
            this.txtExpiry.Size = new System.Drawing.Size(110, 31);
            this.txtExpiry.TabIndex = 18;
            // 
            // txtCVV
            // 
            this.txtCVV.Location = new System.Drawing.Point(406, 235);
            this.txtCVV.Name = "txtCVV";
            this.txtCVV.Size = new System.Drawing.Size(92, 31);
            this.txtCVV.TabIndex = 19;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(150, 300);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(348, 31);
            this.txtName.TabIndex = 20;
            // 
            // MakeBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1857, 745);
            this.Controls.Add(this.pnlBookingHeader);
            this.Controls.Add(this.pnlBookingDetails);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvReturns);
            this.Controls.Add(this.dtReturn);
            this.Controls.Add(this.lblRetDate);
            this.Controls.Add(this.dtDeparture);
            this.Controls.Add(this.lblDepDate);
            this.Controls.Add(this.dgvFlights);
            this.Controls.Add(this.btnSearchFlights);
            this.Name = "MakeBooking";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFlights)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturns)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pnlBookingDetails.ResumeLayout(false);
            this.pnlBookingDetails.PerformLayout();
            this.pnlBookingHeader.ResumeLayout(false);
            this.pnlBookingHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchFlights;
        private System.Windows.Forms.DataGridView dgvFlights;
        private System.Windows.Forms.Label lblDepDate;
        private System.Windows.Forms.DateTimePicker dtDeparture;
        private System.Windows.Forms.Label lblRetDate;
        private System.Windows.Forms.DateTimePicker dtReturn;
        private System.Windows.Forms.DataGridView dgvReturns;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlBookingDetails;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Panel pnlBookingHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCVV;
        private System.Windows.Forms.TextBox txtExpiry;
        private System.Windows.Forms.TextBox txtCardNo;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

