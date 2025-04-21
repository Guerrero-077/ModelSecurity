// formComponent.js
export class FormularioComponent {
    constructor(fields) {
        this.fields = fields;
    }

    render() {
        const formContainer = document.createElement('div');
        formContainer.id = 'form-container';

        const formTitle = document.createElement('h2');
        formTitle.textContent = 'User Form';
        formTitle.className = 'form-title text-white';

        const formElement = document.createElement('form');
        formElement.className = 'form-element';

        // Crear los campos del formulario
        this.fields.forEach(field => {
            const div = document.createElement('div');
            div.className = 'form-group';

            const label = document.createElement('label');
            label.setAttribute('for', field.id);
            label.textContent = field.label;
            label.className = 'form-label text-white';

            const input = document.createElement('input');
            input.type = field.type;
            input.id = field.id;
            input.placeholder = field.placeholder;
            input.className = 'form-control ';

            div.appendChild(label);
            div.appendChild(input);
            formElement.appendChild(div);
        });

        // Crear el botón de enviar
        const submitButton = document.createElement('button');
        submitButton.type = 'submit';
        submitButton.textContent = 'Submit';
        submitButton.className = 'btn btn-primary';

        formElement.appendChild(submitButton); // Agregar el botón al formulario

        // Ahora agregar solo el formulario y el título al contenedor principal
        formContainer.appendChild(formTitle);
        formContainer.appendChild(formElement);

        return formContainer; // Asegúrate de retornar el contenedor completo del formulario
    }
}
