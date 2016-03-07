function doit() {
    var customer = { contact_name: "Scott", company_name: "HP" };
    $.ajax({
        type: "POST",
        data: JSON.stringify(customer),
        url: "api/Adresses",
        contentType: "application/json",
        callback:show
    });
}

function show($data,$textstatus,$jqXHR) {

    console.log($data);
}
