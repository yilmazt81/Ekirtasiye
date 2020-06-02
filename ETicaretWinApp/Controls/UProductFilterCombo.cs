﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ETicaretWinApp.Controls
{
    public partial class UProductFilterCombo : UserControl
    {
        List<string> productList = new List<string>();
        public UProductFilterCombo()
        {
            InitializeComponent();
            try
            {
                comboBoxWebExportState.DataSource = ApiHelper.GetWebExportStatus();
                comboBoxStokSource.DataSource = ApiHelper.GetStockSourceStatus();

                comboBoxInternetFiyat.DataSource = ApiHelper.GetInternetPrice();
                comboBoxStatus.DataSource = new string[] { "Tümü", "Aktif", "Pasif" };

                comboBoxExportHB.Text = "Tümü";
                comboBoxExportN11.Text = "Tümü";
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex);
            }
        }

        public string ProductStatus {
            get {
                return comboBoxStatus.Text;
            }
        }

        public string WebExportState {
            get {
                return comboBoxWebExportState.Text;
            }
        }

        public string StokSource {
            get {
                return comboBoxStokSource.Text;
            }
        }
        public string WebPrice {
            get {
                return comboBoxInternetFiyat.Text;
            }
        }

        public string PriceFilterType { get { return comboBoxPriceFilterType.Text; }set { comboBoxPriceFilterType.Text = value; } }
        public string PriceFilter { get {return textBoxPrice.Text; } set { textBoxPrice.Text = value; } }

        private void buttonStokCodeList_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileLines = File.ReadAllLines(openFileDialog.FileName, Encoding.GetEncoding("Windows-1254"));
                productList = fileLines.Select(s => s).ToList();
                buttonStokCodeList.Text = productList.Count + " Adet Ürün Seçildi";
            }
        }

        public List<string> StokCodeList {
            get {
                return productList;
            }
            set {
                productList = value;
                if (productList.Count == 0)
                {
                    buttonStokCodeList.Text = "Stok Kodu Yükle";
                }
                else
                {
                    buttonStokCodeList.Text = productList.Count + " Adet Ürün Seçildi";

                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            StokCodeList = new List<string>();
        }

        public string ExportHB {
            get => comboBoxExportHB.Text;
            set => comboBoxExportHB.Text = value;
        }

        public string ExportN11 {
            get => comboBoxExportN11.Text;
            set => comboBoxExportN11.Text = value;
        }


    }
}