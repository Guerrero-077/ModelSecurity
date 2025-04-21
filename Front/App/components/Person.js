import { person } from "../Includes/js/Fetch/Select/person.js";

export function PersonComponent() {

    const div = document.createElement('div');

    const title = document.createElement('h1');
    title.className = 'text-white';
    title.textContent = 'Lista de Person';

    const description = document.createElement('p');
    description.className = 'text-white';
    description.textContent = 'Aquí van los Person...';

    const listForm = document.createElement('ul');
    listForm.className = 'list-group list-group-flush';
    listForm.id = 'form-list';

    div.appendChild(title);
    div.appendChild(description);
    div.appendChild(listForm);

    // Usar requestAnimationFrame para asegurarse de que el DOM esté listo
    requestAnimationFrame(() => {
        person(); // Llama a la función form() para cargar los datos
    });
    return div;
}
