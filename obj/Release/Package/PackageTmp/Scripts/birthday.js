//----------Отчет в PDF список сотрудников -----------------------
function GroupReport() {

    //$("#search").html("");
    //var x = document.getElementById("loadImg");
    //x.style.display = "block";

    
    var stringhref = "/Home/ExportGroup?";
    
    stringhref += "dataS=" + $('#dataS').val() + "&" + "dataPo=" + $('#dataPo').val();
    //window.open(stringhref, '_blank');
    window.location = stringhref;
}

function GetLastName() {

    var isValid = true;
        

    if ($('#SearchName').val() == "") {
        $('#SearchName').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#SearchName').css('border-color', 'lightgrey');
    }


    if (isValid == false) {
        return false;
    }

    var data = {
        //'ID': ID,
        'str': $('#SearchName').val()
        
    };

    $("#search").html("");

    var x = document.getElementById("loadImg");
    x.style.display = "block";

    $.ajax({
        url: "/Home/GetLastName",
        type: "POST",
        contentType: "application/json;charset=UTF-8",
        data: JSON.stringify(data),
        dataType: "html",
        success: function (data) {
            x.style.display = "none";
            $('#search').hide();
            $('#search').html(data).animate({ opacity: 'show' }, "slow");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });

}