import ApiModel from "../Models/ApiModel.js";
import EntityView from "../views/EntityView.js";

export default class EntityController {
    constructor(entidad, viewContainerId, campos = [], headers = {}) {
        this.modelo = new ApiModel(entidad, headers);
        this.vista = new EntityView(viewContainerId);
        this.campos = campos;
    }

    async init() {
        try {
            const datos = await this.modelo.getAll();
            this.vista.renderTable(datos, this.campos);
            console.log(datos);
        } catch (error) {
            console.error(error);
            this.vista.showError("No se pudieron cargar los datos.");
        }
    }
}
