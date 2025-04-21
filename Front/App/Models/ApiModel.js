export default class ApiModel {
    constructor(entidad, headers = {}) {
        this.baseUrl = `https://localhost:44329/api/${entidad}`;
        this.headers = {
            "Content-Type": "application/json",
            ...headers
        };
    }

    async getAll() {
        const response = await fetch(this.baseUrl, {
            method: "GET",
            headers: this.headers
        });
        if (!response.ok) throw new Error(`Error al obtener ${this.baseUrl}`);
        return await response.json();
    }

    async getById(id) {
        const response = await fetch(`${this.baseUrl}/${id}`, {
            method: "GET",
            headers: this.headers
        });
        if (!response.ok) throw new Error(`Error al obtener ID ${id}`);
        return await response.json();
    }

    async post(data) {
        const response = await fetch(this.baseUrl, {
            method: "POST",
            headers: this.headers,
            body: JSON.stringify(data)
        });
        return await response.json();
    }

    async put(id, data) {
        const response = await fetch(`${this.baseUrl}/${id}`, {
            method: "PUT",
            headers: this.headers,
            body: JSON.stringify(data)
        });
        return await response.json();
    }

    async delete(id) {
        const response = await fetch(`${this.baseUrl}/${id}`, {
            method: "DELETE",
            headers: this.headers
        });
        return response.ok;
    }
}
