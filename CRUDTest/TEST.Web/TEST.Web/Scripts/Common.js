window.delHandle = function (e) {
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this data!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                swal("Poof! Your data has been deleted!", {
                    icon: "success",
                });
                e.type = "submit";
                setTimeout(() => {
                    e.click();
                }, 800)
                    ;
            } else {
                swal("Your data is safe!");
            }
        });
}

