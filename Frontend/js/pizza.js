let allPizzas = [];

async function fetchVegPizzas() {
    try {
        const response = await fetch('https://localhost:7028/api/Pizza/veg');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const vegPizzas = await response.json();
        return vegPizzas;
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}

async function fetchNonVegPizzas() {
    try {
        const response = await fetch('https://localhost:7028/api/Pizza/nonVeg');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const nonVegPizzas = await response.json();
        return nonVegPizzas;
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}

async function fetchAllPizzas() {
    try {
        const vegPizzas = await fetchVegPizzas();
        const nonVegPizzas = await fetchNonVegPizzas();
        allPizzas = [...vegPizzas, ...nonVegPizzas];
        displayItems(allPizzas, 'pizza');
    } catch (error) {
        console.error('There was a problem with fetching pizzas:', error);
    }
}

function filterItems() {
    const vegCheckbox = document.getElementById('vegCheckbox').checked;
    const nonVegCheckbox = document.getElementById('nonVegCheckbox').checked;

    const filteredPizzas = allPizzas.filter(pizza => {
        if (vegCheckbox && nonVegCheckbox) {
            return true;
        } else if (vegCheckbox) {
            return pizza.isVeg;
        } else if (nonVegCheckbox) {
            return !pizza.isVeg;
        } else {
            return true;
        }
    });

    displayItems(filteredPizzas, 'pizza');
}
document.addEventListener("DOMContentLoaded", () => {
    fetch('https://localhost:7028/api/Topping')
        .then(response => response.json())
        .then(toppings => {
            const toppingOptionsContainer = document.getElementById('toppingOptions');
            
            toppings.forEach(topping => {
                const label = document.createElement('label');
                label.classList.add('topping-item');

                const input = document.createElement('input');
                input.type = 'radio';
                input.name = 'topping';
                input.value = topping.name;
                input.dataset.cost = topping.cost;

                const spanName = document.createElement('span');
                spanName.classList.add('topping-name');
                spanName.textContent = topping.name;

                const spanCost = document.createElement('span');
                spanCost.classList.add('topping-cost');
                spanCost.textContent = `₹${topping.cost}`;

                label.appendChild(input);
                label.appendChild(spanName);
                label.appendChild(spanCost);

                toppingOptionsContainer.appendChild(label);
            });
        })
        .catch(error => console.error('Error fetching toppings:', error));
});
let currentPizzaCost = 0;

async function openStepper(pizza) {
    document.getElementById('stepper-popup').classList.remove('hidden');
    document.querySelector('.step-1').classList.add('active');

    const sizeOptionsContainer = document.getElementById('size-options');
    sizeOptionsContainer.innerHTML = '';

    const sizes = await fetchPizzaSizes(pizza.pizzaId);

    sizes.forEach(size => {
        const label = document.createElement('label');
        label.className = 'radio-label';
        label.innerHTML = `
            <input type="radio" name="size" value="${size.sizeId}" data-name="${size.name}" data-cost="${size.cost.toFixed(2)}">
            <span class="size-name">${size.name}</span>
            <span class="price" id="price-${size.name.toLowerCase()}">₹${size.cost.toFixed(2)}</span>
        `;
        sizeOptionsContainer.appendChild(label);
    });

    // Add event listener to handle size selection
    sizeOptionsContainer.addEventListener('change', event => {
        if (event.target.name === 'size') {
          
            const selectedSizeName = event.target.dataset.name;
            var selectedSizeCost = event.target.dataset.cost;

       
            console.log(`Selected Size Name: ${selectedSizeName}`);
            console.log(`Selected Size Cost: ₹${selectedSizeCost}`);
        }
    });
}

function closeStepper() {
    document.getElementById('stepper-popup').classList.add('hidden');
    document.querySelectorAll('.step').forEach(el => el.classList.remove('active'));
}

function nextStep(step) {
    document.querySelectorAll('.step').forEach(el => el.classList.remove('active'));
    document.querySelector(`.step-${step}`).classList.add('active');

    if (step === 3) {
        const chosenSize = document.querySelector('input[name="size"]:checked').value;
        const chosenCrust = document.querySelector('input[name="crust"]:checked').value;
        document.getElementById('chosen-size').textContent = chosenSize;
        document.getElementById('chosen-crust').textContent = chosenCrust;
    } else if (step === 4) {
        const chosenToppings = Array.from(document.querySelectorAll('input[name="topping"]:checked'))
            .map(checkbox => checkbox.value)
            .join(', ');
        document.getElementById('chosen-toppings').textContent = chosenToppings;
    }
}
function addToCart(pizza) {
    var pizzaId=pizza.pizzaId;
    console.log(`Added to cart: ${pizza.pizzaId}`);
    openStepper(pizza);
}
async function fetchPizzaSizes(pizzaId) {
    try {
        const response = await fetch(`https://localhost:7028/api/Size/cost${pizzaId}`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const sizes = await response.json();
        return sizes;
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}




function finalAddToCart() {
    const size = document.querySelector('input[name="size"]:checked').value;
    const crust = document.querySelector('input[name="crust"]:checked').value;
    const toppings = Array.from(document.querySelectorAll('input[name="topping"]:checked'))
        .map(checkbox => checkbox.value)
        .join(', ');

    let multiplier = 1;
    if (size === 'Medium') {
        multiplier = 1.5;
    } else if (size === 'Large') {
        multiplier = 1.8;
    }

    const basePrice = currentPizzaCost * multiplier;

    let crustMultiplier = 0;
    if (crust === 'Thick') {
        crustMultiplier = 0.15;
    } else if (crust === 'Cheese') {
        crustMultiplier = 0.30;
    }

    const crustAdjustedPrice = basePrice * (1 + crustMultiplier);

    // Calculate total topping cost
    const toppingInputs = document.querySelectorAll('input[name="topping"]:checked');
    let toppingCost = 0;
    toppingInputs.forEach(input => {
        toppingCost += parseFloat(input.getAttribute('data-cost'));
    });

    const finalPrice = crustAdjustedPrice + toppingCost;

    console.log(`Added to cart: Size - ${size}, Crust - ${crust}, Toppings - ${toppings}, Price - ₹${finalPrice.toFixed(2)}`);
    closeStepper();
}



function displayItems(items, type) {
    const container = type === 'pizza' ? document.getElementById('pizzaList') : document.getElementById('beverageContainer');
    container.innerHTML = ''; 

    const currentDate = new Date();

    for (const item of items) {
        const cost = typeof item.cost === 'number' ? item.cost.toFixed(2) : 'N/A';
        const imageUrl = item.image || 'default-image-url.jpg';

        const card = document.createElement('div');
        card.className = 'card';

        const content = document.createElement('div');
        content.classList.add('content');

        const imgContainer = document.createElement('div');
        imgContainer.classList.add('img-container');

        const img = document.createElement('img');
        img.src = imageUrl;
        img.alt = item.name || 'No Image';
        img.classList.add('img');

        const badgeContainer = document.createElement('div');
        badgeContainer.classList.add('badge-container');

        if (item.isBestSeller) {
            const bestSellerBadge = document.createElement('span');
            bestSellerBadge.textContent = 'Bestseller';
            bestSellerBadge.classList.add('bestseller');
            badgeContainer.appendChild(bestSellerBadge);
        }

        const uploadDate = new Date(item.uploadDate);
        const timeDifference = currentDate - uploadDate;
        const daysDifference = timeDifference / (1000 * 3600 * 24);

        if (daysDifference <= 7) {
            const newBadge = document.createElement('span');
            newBadge.textContent = 'New';
            newBadge.classList.add('new');
            badgeContainer.appendChild(newBadge);
        }

        // Adding veg/non-veg badge
        const vegBadge = document.createElement('span');
        vegBadge.textContent = item.isVeg ? 'Veg' : 'Non-Veg';
        vegBadge.classList.add(item.isVeg ? 'veg' : 'non-veg');
        badgeContainer.appendChild(vegBadge);

        const button = document.createElement('button');
        button.textContent = 'Add';
        button.classList.add('button');
        button.onclick = () => addToCart(item); 

        const name = document.createElement('h2');
        name.classList.add('title');
        name.textContent = item.name || 'No Name';

        const description = document.createElement('p');
        description.classList.add('description');
        description.textContent = item.description || 'No Description';

        const volume = document.createElement('p');
        volume.classList.add('volume');
        volume.textContent = `₹${cost}`;

        content.appendChild(name);
        content.appendChild(description);
        content.appendChild(volume);

        imgContainer.appendChild(img);
        imgContainer.appendChild(button);

        card.appendChild(content);
        card.appendChild(imgContainer);
        card.appendChild(badgeContainer);

        container.appendChild(card);
    }
}

fetchAllPizzas();
