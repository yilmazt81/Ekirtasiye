﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EKirtasiye.KadiOgluService.KadiService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Urunler", Namespace="http://tempuri.org/")]
    [System.SerializableAttribute()]
    public partial class Urunler : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private int LogicalrefField;
        
        private int AktifField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KoduField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UrunAdiField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UreticiKodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MarkaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string KategoriField;
        
        private double fiyatHamField;
        
        private double fiyatField;
        
        private int fiyatTuruField;
        
        private int KdvField;
        
        private int stokField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BirimAdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string BarkodField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Barkod2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Barkod3Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Barkod4Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Barkod5Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ResimField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string UstKategoriField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string OrtaKategoriField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string AltKategoriField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string iskonto1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string iskonto2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Ozellik1Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Ozellik2Field;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Ozellik3Field;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true)]
        public int Logicalref {
            get {
                return this.LogicalrefField;
            }
            set {
                if ((this.LogicalrefField.Equals(value) != true)) {
                    this.LogicalrefField = value;
                    this.RaisePropertyChanged("Logicalref");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=1)]
        public int Aktif {
            get {
                return this.AktifField;
            }
            set {
                if ((this.AktifField.Equals(value) != true)) {
                    this.AktifField = value;
                    this.RaisePropertyChanged("Aktif");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string Kodu {
            get {
                return this.KoduField;
            }
            set {
                if ((object.ReferenceEquals(this.KoduField, value) != true)) {
                    this.KoduField = value;
                    this.RaisePropertyChanged("Kodu");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string UrunAdi {
            get {
                return this.UrunAdiField;
            }
            set {
                if ((object.ReferenceEquals(this.UrunAdiField, value) != true)) {
                    this.UrunAdiField = value;
                    this.RaisePropertyChanged("UrunAdi");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string UreticiKod {
            get {
                return this.UreticiKodField;
            }
            set {
                if ((object.ReferenceEquals(this.UreticiKodField, value) != true)) {
                    this.UreticiKodField = value;
                    this.RaisePropertyChanged("UreticiKod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=5)]
        public string Marka {
            get {
                return this.MarkaField;
            }
            set {
                if ((object.ReferenceEquals(this.MarkaField, value) != true)) {
                    this.MarkaField = value;
                    this.RaisePropertyChanged("Marka");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=6)]
        public string Kategori {
            get {
                return this.KategoriField;
            }
            set {
                if ((object.ReferenceEquals(this.KategoriField, value) != true)) {
                    this.KategoriField = value;
                    this.RaisePropertyChanged("Kategori");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=7)]
        public double fiyatHam {
            get {
                return this.fiyatHamField;
            }
            set {
                if ((this.fiyatHamField.Equals(value) != true)) {
                    this.fiyatHamField = value;
                    this.RaisePropertyChanged("fiyatHam");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=8)]
        public double fiyat {
            get {
                return this.fiyatField;
            }
            set {
                if ((this.fiyatField.Equals(value) != true)) {
                    this.fiyatField = value;
                    this.RaisePropertyChanged("fiyat");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=9)]
        public int fiyatTuru {
            get {
                return this.fiyatTuruField;
            }
            set {
                if ((this.fiyatTuruField.Equals(value) != true)) {
                    this.fiyatTuruField = value;
                    this.RaisePropertyChanged("fiyatTuru");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=10)]
        public int Kdv {
            get {
                return this.KdvField;
            }
            set {
                if ((this.KdvField.Equals(value) != true)) {
                    this.KdvField = value;
                    this.RaisePropertyChanged("Kdv");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(IsRequired=true, Order=11)]
        public int stok {
            get {
                return this.stokField;
            }
            set {
                if ((this.stokField.Equals(value) != true)) {
                    this.stokField = value;
                    this.RaisePropertyChanged("stok");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=12)]
        public string BirimAd {
            get {
                return this.BirimAdField;
            }
            set {
                if ((object.ReferenceEquals(this.BirimAdField, value) != true)) {
                    this.BirimAdField = value;
                    this.RaisePropertyChanged("BirimAd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=13)]
        public string Barkod {
            get {
                return this.BarkodField;
            }
            set {
                if ((object.ReferenceEquals(this.BarkodField, value) != true)) {
                    this.BarkodField = value;
                    this.RaisePropertyChanged("Barkod");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=14)]
        public string Barkod2 {
            get {
                return this.Barkod2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Barkod2Field, value) != true)) {
                    this.Barkod2Field = value;
                    this.RaisePropertyChanged("Barkod2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=15)]
        public string Barkod3 {
            get {
                return this.Barkod3Field;
            }
            set {
                if ((object.ReferenceEquals(this.Barkod3Field, value) != true)) {
                    this.Barkod3Field = value;
                    this.RaisePropertyChanged("Barkod3");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=16)]
        public string Barkod4 {
            get {
                return this.Barkod4Field;
            }
            set {
                if ((object.ReferenceEquals(this.Barkod4Field, value) != true)) {
                    this.Barkod4Field = value;
                    this.RaisePropertyChanged("Barkod4");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=17)]
        public string Barkod5 {
            get {
                return this.Barkod5Field;
            }
            set {
                if ((object.ReferenceEquals(this.Barkod5Field, value) != true)) {
                    this.Barkod5Field = value;
                    this.RaisePropertyChanged("Barkod5");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=18)]
        public string Resim {
            get {
                return this.ResimField;
            }
            set {
                if ((object.ReferenceEquals(this.ResimField, value) != true)) {
                    this.ResimField = value;
                    this.RaisePropertyChanged("Resim");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=19)]
        public string UstKategori {
            get {
                return this.UstKategoriField;
            }
            set {
                if ((object.ReferenceEquals(this.UstKategoriField, value) != true)) {
                    this.UstKategoriField = value;
                    this.RaisePropertyChanged("UstKategori");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=20)]
        public string OrtaKategori {
            get {
                return this.OrtaKategoriField;
            }
            set {
                if ((object.ReferenceEquals(this.OrtaKategoriField, value) != true)) {
                    this.OrtaKategoriField = value;
                    this.RaisePropertyChanged("OrtaKategori");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=21)]
        public string AltKategori {
            get {
                return this.AltKategoriField;
            }
            set {
                if ((object.ReferenceEquals(this.AltKategoriField, value) != true)) {
                    this.AltKategoriField = value;
                    this.RaisePropertyChanged("AltKategori");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=22)]
        public string iskonto1 {
            get {
                return this.iskonto1Field;
            }
            set {
                if ((object.ReferenceEquals(this.iskonto1Field, value) != true)) {
                    this.iskonto1Field = value;
                    this.RaisePropertyChanged("iskonto1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=23)]
        public string iskonto2 {
            get {
                return this.iskonto2Field;
            }
            set {
                if ((object.ReferenceEquals(this.iskonto2Field, value) != true)) {
                    this.iskonto2Field = value;
                    this.RaisePropertyChanged("iskonto2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=24)]
        public string Ozellik1 {
            get {
                return this.Ozellik1Field;
            }
            set {
                if ((object.ReferenceEquals(this.Ozellik1Field, value) != true)) {
                    this.Ozellik1Field = value;
                    this.RaisePropertyChanged("Ozellik1");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=25)]
        public string Ozellik2 {
            get {
                return this.Ozellik2Field;
            }
            set {
                if ((object.ReferenceEquals(this.Ozellik2Field, value) != true)) {
                    this.Ozellik2Field = value;
                    this.RaisePropertyChanged("Ozellik2");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=26)]
        public string Ozellik3 {
            get {
                return this.Ozellik3Field;
            }
            set {
                if ((object.ReferenceEquals(this.Ozellik3Field, value) != true)) {
                    this.Ozellik3Field = value;
                    this.RaisePropertyChanged("Ozellik3");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="KadiService.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: Generating message contract since element name KullaniciKod from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UrunListesi", ReplyAction="*")]
        EKirtasiye.KadiOgluService.KadiService.UrunListesiResponse UrunListesi(EKirtasiye.KadiOgluService.KadiService.UrunListesiRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UrunListesi", ReplyAction="*")]
        System.Threading.Tasks.Task<EKirtasiye.KadiOgluService.KadiService.UrunListesiResponse> UrunListesiAsync(EKirtasiye.KadiOgluService.KadiService.UrunListesiRequest request);
        
        // CODEGEN: Generating message contract since element name KullaniciKod from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UrunListesi2", ReplyAction="*")]
        EKirtasiye.KadiOgluService.KadiService.UrunListesi2Response UrunListesi2(EKirtasiye.KadiOgluService.KadiService.UrunListesi2Request request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/UrunListesi2", ReplyAction="*")]
        System.Threading.Tasks.Task<EKirtasiye.KadiOgluService.KadiService.UrunListesi2Response> UrunListesi2Async(EKirtasiye.KadiOgluService.KadiService.UrunListesi2Request request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UrunListesiRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UrunListesi", Namespace="http://tempuri.org/", Order=0)]
        public EKirtasiye.KadiOgluService.KadiService.UrunListesiRequestBody Body;
        
        public UrunListesiRequest() {
        }
        
        public UrunListesiRequest(EKirtasiye.KadiOgluService.KadiService.UrunListesiRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UrunListesiRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string KullaniciKod;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Sifre;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string stokDurum;
        
        public UrunListesiRequestBody() {
        }
        
        public UrunListesiRequestBody(string KullaniciKod, string Sifre, string stokDurum) {
            this.KullaniciKod = KullaniciKod;
            this.Sifre = Sifre;
            this.stokDurum = stokDurum;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UrunListesiResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UrunListesiResponse", Namespace="http://tempuri.org/", Order=0)]
        public EKirtasiye.KadiOgluService.KadiService.UrunListesiResponseBody Body;
        
        public UrunListesiResponse() {
        }
        
        public UrunListesiResponse(EKirtasiye.KadiOgluService.KadiService.UrunListesiResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UrunListesiResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public EKirtasiye.KadiOgluService.KadiService.Urunler[] UrunListesiResult;
        
        public UrunListesiResponseBody() {
        }
        
        public UrunListesiResponseBody(EKirtasiye.KadiOgluService.KadiService.Urunler[] UrunListesiResult) {
            this.UrunListesiResult = UrunListesiResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UrunListesi2Request {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UrunListesi2", Namespace="http://tempuri.org/", Order=0)]
        public EKirtasiye.KadiOgluService.KadiService.UrunListesi2RequestBody Body;
        
        public UrunListesi2Request() {
        }
        
        public UrunListesi2Request(EKirtasiye.KadiOgluService.KadiService.UrunListesi2RequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UrunListesi2RequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string KullaniciKod;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string Sifre;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string stokDurum;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string SonGuncellenme;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string OlusturmaTarihi;
        
        public UrunListesi2RequestBody() {
        }
        
        public UrunListesi2RequestBody(string KullaniciKod, string Sifre, string stokDurum, string SonGuncellenme, string OlusturmaTarihi) {
            this.KullaniciKod = KullaniciKod;
            this.Sifre = Sifre;
            this.stokDurum = stokDurum;
            this.SonGuncellenme = SonGuncellenme;
            this.OlusturmaTarihi = OlusturmaTarihi;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class UrunListesi2Response {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="UrunListesi2Response", Namespace="http://tempuri.org/", Order=0)]
        public EKirtasiye.KadiOgluService.KadiService.UrunListesi2ResponseBody Body;
        
        public UrunListesi2Response() {
        }
        
        public UrunListesi2Response(EKirtasiye.KadiOgluService.KadiService.UrunListesi2ResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class UrunListesi2ResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public EKirtasiye.KadiOgluService.KadiService.Urunler[] UrunListesi2Result;
        
        public UrunListesi2ResponseBody() {
        }
        
        public UrunListesi2ResponseBody(EKirtasiye.KadiOgluService.KadiService.Urunler[] UrunListesi2Result) {
            this.UrunListesi2Result = UrunListesi2Result;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : EKirtasiye.KadiOgluService.KadiService.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<EKirtasiye.KadiOgluService.KadiService.WebService1Soap>, EKirtasiye.KadiOgluService.KadiService.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EKirtasiye.KadiOgluService.KadiService.UrunListesiResponse EKirtasiye.KadiOgluService.KadiService.WebService1Soap.UrunListesi(EKirtasiye.KadiOgluService.KadiService.UrunListesiRequest request) {
            return base.Channel.UrunListesi(request);
        }
        
        public EKirtasiye.KadiOgluService.KadiService.Urunler[] UrunListesi(string KullaniciKod, string Sifre, string stokDurum) {
            EKirtasiye.KadiOgluService.KadiService.UrunListesiRequest inValue = new EKirtasiye.KadiOgluService.KadiService.UrunListesiRequest();
            inValue.Body = new EKirtasiye.KadiOgluService.KadiService.UrunListesiRequestBody();
            inValue.Body.KullaniciKod = KullaniciKod;
            inValue.Body.Sifre = Sifre;
            inValue.Body.stokDurum = stokDurum;
            EKirtasiye.KadiOgluService.KadiService.UrunListesiResponse retVal = ((EKirtasiye.KadiOgluService.KadiService.WebService1Soap)(this)).UrunListesi(inValue);
            return retVal.Body.UrunListesiResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<EKirtasiye.KadiOgluService.KadiService.UrunListesiResponse> EKirtasiye.KadiOgluService.KadiService.WebService1Soap.UrunListesiAsync(EKirtasiye.KadiOgluService.KadiService.UrunListesiRequest request) {
            return base.Channel.UrunListesiAsync(request);
        }
        
        public System.Threading.Tasks.Task<EKirtasiye.KadiOgluService.KadiService.UrunListesiResponse> UrunListesiAsync(string KullaniciKod, string Sifre, string stokDurum) {
            EKirtasiye.KadiOgluService.KadiService.UrunListesiRequest inValue = new EKirtasiye.KadiOgluService.KadiService.UrunListesiRequest();
            inValue.Body = new EKirtasiye.KadiOgluService.KadiService.UrunListesiRequestBody();
            inValue.Body.KullaniciKod = KullaniciKod;
            inValue.Body.Sifre = Sifre;
            inValue.Body.stokDurum = stokDurum;
            return ((EKirtasiye.KadiOgluService.KadiService.WebService1Soap)(this)).UrunListesiAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        EKirtasiye.KadiOgluService.KadiService.UrunListesi2Response EKirtasiye.KadiOgluService.KadiService.WebService1Soap.UrunListesi2(EKirtasiye.KadiOgluService.KadiService.UrunListesi2Request request) {
            return base.Channel.UrunListesi2(request);
        }
        
        public EKirtasiye.KadiOgluService.KadiService.Urunler[] UrunListesi2(string KullaniciKod, string Sifre, string stokDurum, string SonGuncellenme, string OlusturmaTarihi) {
            EKirtasiye.KadiOgluService.KadiService.UrunListesi2Request inValue = new EKirtasiye.KadiOgluService.KadiService.UrunListesi2Request();
            inValue.Body = new EKirtasiye.KadiOgluService.KadiService.UrunListesi2RequestBody();
            inValue.Body.KullaniciKod = KullaniciKod;
            inValue.Body.Sifre = Sifre;
            inValue.Body.stokDurum = stokDurum;
            inValue.Body.SonGuncellenme = SonGuncellenme;
            inValue.Body.OlusturmaTarihi = OlusturmaTarihi;
            EKirtasiye.KadiOgluService.KadiService.UrunListesi2Response retVal = ((EKirtasiye.KadiOgluService.KadiService.WebService1Soap)(this)).UrunListesi2(inValue);
            return retVal.Body.UrunListesi2Result;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<EKirtasiye.KadiOgluService.KadiService.UrunListesi2Response> EKirtasiye.KadiOgluService.KadiService.WebService1Soap.UrunListesi2Async(EKirtasiye.KadiOgluService.KadiService.UrunListesi2Request request) {
            return base.Channel.UrunListesi2Async(request);
        }
        
        public System.Threading.Tasks.Task<EKirtasiye.KadiOgluService.KadiService.UrunListesi2Response> UrunListesi2Async(string KullaniciKod, string Sifre, string stokDurum, string SonGuncellenme, string OlusturmaTarihi) {
            EKirtasiye.KadiOgluService.KadiService.UrunListesi2Request inValue = new EKirtasiye.KadiOgluService.KadiService.UrunListesi2Request();
            inValue.Body = new EKirtasiye.KadiOgluService.KadiService.UrunListesi2RequestBody();
            inValue.Body.KullaniciKod = KullaniciKod;
            inValue.Body.Sifre = Sifre;
            inValue.Body.stokDurum = stokDurum;
            inValue.Body.SonGuncellenme = SonGuncellenme;
            inValue.Body.OlusturmaTarihi = OlusturmaTarihi;
            return ((EKirtasiye.KadiOgluService.KadiService.WebService1Soap)(this)).UrunListesi2Async(inValue);
        }
    }
}
