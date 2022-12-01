window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation successful")
    }
    if (type === "error") {
        toastr.error(message, "Operation Failed")
    }
}

window.ShowSweetAlert = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success notification',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Really bad, sorry',
            message,
            'error'
        )
    }
}