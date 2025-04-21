const menu = document.getElementById('menu');


export class Menu {
    constructor(items) {
        this.items = items;
        this.render();
    }

    render() {
        const menuContainer = document.createElement('nav');

        const menuTitle = document.createElement('h2');
        menuTitle.textContent = 'Model Secutity';
        menuTitle.className = 'menu-title';

        const ul = document.createElement('ul');
        ul.className = 'list nav nav-pills flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start';

        this.items.forEach(item => {
            const li = document.createElement('li');
            li.className = 'nav-item element';
            const a = document.createElement('a');
            a.className = 'label nav nav-link align-middle px-0';
            a.href = item.href;
            a.textContent = item.name;
            li.appendChild(a);
            ul.appendChild(li);
        });

        menuContainer.appendChild(menuTitle);
        menuContainer.appendChild(ul);
        menu.appendChild(menuContainer);
    }
}
