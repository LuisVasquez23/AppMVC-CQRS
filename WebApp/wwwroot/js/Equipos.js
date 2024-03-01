const DeletePersonaEvent = (personaId) => {
    Swal.fire({
        title: '¿Estás seguro?',
        text: 'No podrás deshacer esta acción',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#d33',
        cancelButtonColor: '#3085d6',
        confirmButtonText: 'Sí, eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            $(`#deleteForm-${personaId}`).submit();
        }
    });
}

function MessageAlert(mensaje, tipo) {
    Swal.fire({
        title: '',
        text: mensaje,
        icon: tipo,
        confirmButtonText: 'Aceptar'
    });
}