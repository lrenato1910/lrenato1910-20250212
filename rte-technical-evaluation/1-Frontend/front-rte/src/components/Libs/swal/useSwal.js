import Swal from 'sweetalert2';

const useSweetAlert = () => {
  const showAlert = (options) => {
    Swal.fire(options);
  };

  const showSuccess = (message) => {
    Swal.fire({
      title: 'Sucesso!',
      text: message,
      icon: 'success',
      confirmButtonText: 'OK',
    });
  };

  const showError = (message) => {
    Swal.fire({
      title: 'Erro!',
      text: message,
      icon: 'error',
      confirmButtonText: 'OK',
    });
  };

  const showConfirmation = (title, message) => {
    return Swal.fire({
      title: title,
      text: message,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Sim',
      cancelButtonText: 'Cancelar',
    });
  };

  const showInputAlert = (title, inputLabel) => {
    return Swal.fire({
      title: title,
      input: 'text',
      inputLabel: inputLabel,
      showCancelButton: true,
      confirmButtonText: 'Enviar',
      cancelButtonText: 'Cancelar',
    });
  };

  return { showAlert, showSuccess, showError, showConfirmation, showInputAlert };
};

export default useSweetAlert;