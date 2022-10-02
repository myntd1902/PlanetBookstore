$('input[name="option_payment"]').off('click').on('click', function () {
    if ($(this).val() == 'NL') {
        $('.boxContent').hide();
        $('#NLContent').show();
    }
    else if ($(this).val() == 'ATM_ONLINE') {
        $('.boxContent').hide();
        $('#ATMContent').show();
    }
    else {
        $('.boxContent').hide();
    }
});


//CreatePayment: function () {
//    var pm = {
//        PaymentMethod: $('input[name="option_payment"]:checked').val(),
//        BankCode: $('input[groupname="bankcode"]:checked').prop('id')
//    }
//}