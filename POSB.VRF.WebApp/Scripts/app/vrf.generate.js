$(document).ready(function () {
    
$("#btnVRFSubmit").click(function (event) {
    //event.preventDefault();
        
    var VisitStartDate = $("#VisitStartDate").data("kendoDateTimePicker");
    var VisitEndDate = $("#VisitEndDate").data("kendoDateTimePicker");
    var VisitorTypeId = $("#VisitorTypeId").data("kendoDropDownList");
    var msgWarning = "";

    var VisitorName = $("#VisitorName").val();
    var VisitorEmail = $("#VisitorEmail").val();
    var VisitorPhone = $("#VisitorPhone").val();
    var VisitorCompany = $("#VisitorCompany").val();
    var myStart = new Date(VisitStartDate.value()); 
    var myEnd = new Date(VisitEndDate.value()); 
    var VisitPurpose = $("#VisitPurpose").val();
    var myVisitorType = VisitorTypeId.value();

    console.log(VisitorName + "/" + VisitorEmail + "/" + VisitorPhone + "/" + VisitorCompany + "/" + myStart + "" + myEnd + "/" + VisitPurpose + "/" + myVisitorType);

    if (VisitorName == '') {
        toastr["error"]("Please enter name !");
        return false;
    }

    if (VisitorEmail == '') {
        toastr["error"]("Please enter email !");
        return false;
    }

    if (!validateEmail(VisitorEmail)) {
        toastr["error"]("Please enter valid email !");
        return false;
    }

    if (VisitorPhone == '') {
        toastr["error"]("Please enter email !");
        return false;
    }

    if (!validatePhone(VisitorPhone)) {
        toastr["error"]("Please enter valid phone number !");
        return false;
    }
        
    if (myVisitorType == 0) {
        toastr["error"]("Please select visitor type !");
        return false;
    }

    if (myStart != null && myEnd != null) {
        //toastr["error"](myStart);
            
        if (myEnd.getTime() === myStart.getTime()) {
            toastr["error"]("Start date & end date cannot have same value !");
            return false;
        }

        if (myEnd.getTime() < myStart.getTime()) {
            toastr["error"]("Start date is bigger then end date !");
            return false;
        }

    }

    return true;
        
});


});

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function validatePhone(phone) {
    var re = /^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$/im;
    return re.test(phone);
}