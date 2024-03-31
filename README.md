Merhaba,

Bu repository'de Kaizen için hazırlamış olduğum Case Study'lerin cevaplarını bulabilirsiniz.

- İlk maddede, bir gıda firmasının ürün ambalajları içerisine yerleştirmek istedikleri 8 karakterli unique kodların generate edilmesi için bir servis oluşturulmuştur.
 Bu servis bir sayı parametresi almaktadır. Böylece istenildiği kadar kod aynı anda, farklı ürünler için(proje içerisinde örnek olarak "Coca Cola","Pepsi","Magnum" seçilmiştir) Oluşturabilmektedir.
- Bu madde özelinde, kod üretme işleminin belirli bir kurala uygun olması adına, rastgele üretilen bir sayının kübü alındıktan sonra karakter dizisi uzunluğuna göre mod alınarak bir örüntü içerisinde kodların üretilmesi sağlanmıştır.
- Bu madde ile ilgili servisi tetiklemek için "https://localhost:7004/RandomCodeGenerate?count=1000" isteğini kullanabilirsiniz.

- İkinci maddede, OCR aşaması için okunan bir fişe ait JSON dosyasının, OCR çıktısına göre işlenip uygun formatta metine dönüştürülmesi için bir çalışma yapılmıştır.
- Kod ile ilgili açıklamalar kod içerisine comment olarak atılmıştır.
- Bu madde ile ilgili servisi tetiklemek için "https://localhost:7004/PostBillParse" isteğini kullanabilirsiniz.
