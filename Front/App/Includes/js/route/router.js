import { PersonComponent } from './../../../components/Person.js';
import { FormComponent } from './../../../components/Form.js';

const routes = {
  '/person': PersonComponent,
  '/form': FormComponent
};

export function router() {
  const app = document.getElementById('app');
  app.innerHTML = ''; // Limpia el contenedor

  const path = location.hash.slice(1) || '/';
  const component = routes[path];

  if (component) {
    app.appendChild(component());
  } else {
    app.innerHTML = '<h1>404 - Página no encontrada</h1>';
  }
}
