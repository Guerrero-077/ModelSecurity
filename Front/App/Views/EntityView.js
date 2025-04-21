export default class EntityView {
    constructor(containerId) {
        this.container = document.getElementById(containerId);
        if (!this.container) {
            console.error(`Contenedor con ID "${containerId}" no encontrado`);
            return;
        }
    }

    renderList(items, campos = []) {
        if (!this.container) return; // Evitar errores si no se encuentra el contenedor

        this.container.innerHTML = "";
        items.forEach(item => {
            const li = document.createElement("li");
            li.className = "list-group-item list-group-item-action";
            li.textContent = campos.map(c => item[c]).join(" - ");
            this.container.appendChild(li);
        });
    }
    renderTable(items, campos = []) {
        if (!this.container) return;

        this.container.innerHTML = "";

        items.forEach((item, index) => {
            const tr = document.createElement("tr");

            // Índice
            const tdIndex = document.createElement("td");
            tdIndex.textContent = index + 1;
            tr.appendChild(tdIndex);

            // Campos dinámicos
            campos.forEach(campo => {
                const td = document.createElement("td");
                td.textContent = item[campo] ?? '';
                tr.appendChild(td);
            });

            // Botones de acción
            const tdActions = document.createElement("td");
            tdActions.innerHTML = `
                <button class="btn btn-sm btn-primary me-2">Edit</button>
                <button class="btn btn-sm btn-danger">Delete</button>
            `;
            tr.appendChild(tdActions);

            this.container.appendChild(tr);
        });
    }


    showError(message) {
        if (!this.container) return;
        this.container.innerHTML = `<p style="color: red;">${message}</p>`;
    }
}
