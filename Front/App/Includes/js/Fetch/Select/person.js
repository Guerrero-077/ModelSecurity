import EntityController from '../../../../Controller/EntityController.js';

export function person() {
    const headers = {
        "Accept": "application/json"
    };

    // Ejemplo con la entidad "Form"
    const formController = new EntityController("person", "form-list", ["full_name", "phone_number"], headers);
    formController.init();

}

