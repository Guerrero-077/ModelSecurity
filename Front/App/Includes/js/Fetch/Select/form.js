import EntityController from '../../../../Controller/EntityController.js';

export function form() {
    const headers = {
        "Accept": "application/json"
    };

    // Ejemplo con la entidad "Form"
    const formController = new EntityController("Form", "form-list", ["name", "description"], headers);
    formController.init();

}

