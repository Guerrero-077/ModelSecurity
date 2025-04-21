import { form } from "../Includes/js/Fetch/Select/form.js";
import { FormularioComponent } from "../Includes/js/Form/formComponent.js";


const formFields = [
    { label: 'Name', type: 'text', id: 'name', placeholder: 'Enter your name' },
    { label: 'description', type: 'text', id: 'description', placeholder: 'Enter your description' }
];
export function FormComponent() {
    const div = document.createElement('div');
    const divContainer = document.createElement('div');
    const divList = document.createElement('div');
    const listForm = document.createElement('ul');
    const formularioForm = new FormularioComponent(formFields);
    const formRenderizado = formularioForm.render();

    // Bootstrap classes
    divContainer.className = "container mt-4";
    divList.className = "table-responsive";

    // Crear tabla Bootstrap
    const table = document.createElement('table');
    table.className = "table table-striped table-bordered";

    // Crear thead
    const thead = document.createElement('thead');
    thead.innerHTML = `
        <tr class="table-dark">
            <th scope="col">#</th>
            <th scope="col">Name Completed</th>
            <th scope="col">Phone Number</th>
            <th scope="col">Actions</th>
        </tr>
    `;

    // Crear tbody
    const tbody = document.createElement('tbody');
    tbody.id = "form-list"; // Este será usado por EntityView

    // Insertar partes en la tabla
    table.appendChild(thead);
    table.appendChild(tbody);

    // Armar estructura del componente
    divContainer.appendChild(formRenderizado); // Form arriba
    divContainer.appendChild(divList);         // Tabla abajo
    divList.appendChild(table);

    div.appendChild(divContainer);
    div.appendChild(listForm);

    // Cargar datos después del render
    requestAnimationFrame(() => {
        form(); // Esta función llenará la tabla usando EntityView
    });

    return div;
}




