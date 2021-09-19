
var url = "https://localhost:44357/api";

$( document ).ready(function() {

  LoadDataDemo();
  var IP = '';
  $.getJSON("https://api.ipify.org?format=json", function (data) { IP = data.ip; });

  $( "#formcontact" ).submit(function( event ) {
    event.preventDefault();
    var name = $("#txtname").val();
    var phone = $("#txtphone").val();
    var message = $("#txtmessage").val();
    if(MessageisNull(message)){
      return;
    }
    if(isMobileNumber(phone)){
      // thông tin hợp lệ submit lên server
      var data  = { 
        id: 0,
        name: name,
        phone: phone,
        message: message,
        ip: IP,
      }

      $.cookie('thongtin', JSON.stringify(data));

      postAjax(data);
    }
       
  }); 

});

function Load(page){
  if(page == 'contact'){
    $("#loading").load("contact.html");
  }else{
    $("#loading").load("service.html");
  }
}

function LoadContact(){
  const httpHeaders = getHTTPHeaders();
  $.ajax({
    url: url + '/contacts',
    type: 'get',
    dataType: 'json',
    headers: httpHeaders,

  }).done(function( data ) {
    console.log(data);
    if(data.status == 1){
      var texthtml = '';
      const res = data.data;
      if(res){
        $.each(res, function(i, res) {
          $('#table1').find('tbody')
              .append('<tr>')
              .append('<td>' + res.name + '</td>')
              .append('<td>' + res.phone + '</td>')
              .append('<td >' + res.message + '</td>')
              .append('<td>' + res.ip + '</td>')
              .append('<td >' + res.createddate + '</td>')
              .append('<tr>');
      });
      }else{
        $('#demo').html('Không có dữ liệu');
      }
    }else{
      alert(data.error);
    } 
  })
.fail( function(xhr, textStatus, errorThrown) {
  console.log("err",xhr.responseText,textStatus);
});
}

function postAjax(object){
  const httpHeaders = getHTTPHeaders();
  $.ajax({
    url: url + '/contacts',
    type: 'post', 
    contentType: 'application/json',
    data: JSON.stringify(object),
    dataType: 'json',
    headers: httpHeaders,

    success: function (data) {
      console.log(data);
      if(data.status == 1){
        alert('Thêm thành công');
        window.location.reload();
      }else{
        alert(data.error);
      }
    },

});

}

function LoadDataDemo(){
  const cookie = $.cookie('thongtin');
  if(cookie){
    var thongtin = JSON.parse(cookie);
    console.log(thongtin);
    $("#txtname").val(thongtin.name);
    $("#txtphone").val(thongtin.phone) ;
  }else{
    console.log('First sign no has cookie');
  }
}

function isMobileNumber(phonenumber){
  var vnf_regex = /((0)+(9|3|7|8|5)+([0-9]{8})\b)/g;
  if(phonenumber !==''){
      if (vnf_regex.test(phonenumber) == false) 
      {
          alert('Số điện thoại của bạn không đúng định dạng!');
          return false;
      }else{
          // Số điện thoại hợp lệ!;
          return true;
      }
  }else{
      alert('Bạn chưa điền số điện thoại!');
      return false;
  }
};

function MessageisNull(content){
  if(content.trim() ==''){
      alert('Nội dung gửi không thể để trống!');
      return true; 
  }else{
    return false;
  }
};

function ClearCookie(){
  $.removeCookie('thongtin');
}

function getHTTPHeaders() {
  let result = {
      'Content-Type': 'application/json',
      "Access-Control-Allow-Origin": "*", 
      'Access-Control-Allow-Headers': 'Content-Type', 
  };
  return result;
}

