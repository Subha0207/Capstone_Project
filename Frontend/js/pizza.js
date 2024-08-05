
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
function finalAddToCart() {
    // Get the details from local storage
    const userId = localStorage.getItem('userId');
    const pizzaId = localStorage.getItem('pizzaId');
    const crustId = localStorage.getItem('selectedCrustId');
    const toppingId = localStorage.getItem('selectedToppingId');
    const sizeId = localStorage.getItem('selectedSizeId');

    // Create the payload
    const payload = {
        userId: parseInt(userId, 10),
        pizzaId: parseInt(pizzaId, 10),
        crustId: parseInt(crustId, 10),
        toppingId: parseInt(toppingId, 10),
        sizeId: parseInt(sizeId, 10)
    };

    // Make the POST request
    fetch('https://localhost:7028/api/CartItem/PizzaCartItem', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
    })
        .then(response => response.json())
        .then(data => {
            console.log('Response from server:', data);
            if (Number.isInteger(data)) {
                // Set a flag in local storage to show a popup on the original page
                localStorage.setItem('cartAddSuccess', 'true');
                closeStepper();  
                showPopupMessage('Added to add item to cart.', true);
              

            } else {
                showPopupMessage('Failed to add item to cart.', true);
            }
        })
        .catch((error) => {
            console.error('Error adding item to cart:', error);
            showPopupMessage('Error adding item to cart.', true);
        });
}
document.addEventListener('DOMContentLoaded', () => {
    // Check if the cart add success flag is set
    if (localStorage.getItem('cartAddSuccess') === 'true') {
        // Show success popup message
        showPopupMessage('Item added to cart successfully!');
        // Remove the flag from local storage
        localStorage.removeItem('cartAddSuccess');
    }
});
function showPopupMessage(message, isError = false) {
    const popupMessage = document.getElementById('popupMessage');
    popupMessage.textContent = message;
    popupMessage.classList.toggle('error', isError);
    popupMessage.style.display = 'block';

    setTimeout(() => {
        popupMessage.style.display = 'none';
    }, 3000);
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
                input.dataset.id = topping.toppingId;// Include the topping ID in a data attribute
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

            // Add event listener to handle topping selection
            toppingOptionsContainer.addEventListener('change', event => {
                if (event.target.name === 'topping') {
                    const selectedToppingId = event.target.dataset.id;
                    const selectedToppingName = event.target.value;

                    // Store the selected topping ID and name in local storage
                    localStorage.setItem('selectedToppingId', selectedToppingId);
                    localStorage.setItem('selectedToppingName', selectedToppingName);

                    // Print the selected topping ID and name in the console
                    console.log(`Selected Topping ID: ${selectedToppingId}`);
                    console.log(`Selected Topping Name: ${selectedToppingName}`);
                }
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
            const selectedSizeId = event.target.value;
            const selectedSizeName = event.target.getAttribute('data-name');

            // Store the selected size ID in local storage
            localStorage.setItem('selectedSizeId', selectedSizeId);

            // Print the selected size ID and name in the console
            console.log(`Selected Size ID: ${selectedSizeId}`);
            console.log(`Selected Size Name: ${selectedSizeName}`);
            localStorage.setItem('selectedSize', selectedSizeName);
        }
    });

    // Store pizzaId in local storage
    localStorage.setItem('pizzaId', pizza.pizzaId);
}
async function loadCrustOptions() {
    const pizzaId = localStorage.getItem('pizzaId');
    const sizeId = localStorage.getItem('selectedSizeId');

    if (!pizzaId || !sizeId) {
        console.error('Pizza ID or Size ID is not set in local storage.');
        return;
    }

    const crustCosts = await fetchCrustCosts(pizzaId, sizeId);

    const crustOptionsContainer = document.getElementById('crust-options');
    crustOptionsContainer.innerHTML = '';

    crustCosts.forEach(crust => {
        console.log(crust);
        const label = document.createElement('label');
        label.className = 'radio-label';
        label.innerHTML = `
    <input type="radio" name="crust" value="${crust.crustId}" data-name="${crust.name}" data-cost="${crust.cost.toFixed(2)}">
    <span class="crust-name">${crust.name}</span>
    <span class="price" id="price-${crust.name.toLowerCase()}">₹${crust.cost.toFixed(2)}</span>
`;
        crustOptionsContainer.appendChild(label);
    });

    // Add event listener to handle crust selection and store the selected crust ID
    crustOptionsContainer.addEventListener('change', event => {
        if (event.target.name === 'crust') {
            const selectedCrustId = event.target.value;
            const selectedCrustName = event.target.dataset.name;
            const selectedCrustCost = event.target.dataset.cost;

            // Store the selected crust ID, name, and cost in local storage
            localStorage.setItem('selectedCrustId', selectedCrustId);
            localStorage.setItem('selectedCrustName', selectedCrustName);



        }
    });
}


function closeStepper() {
    document.getElementById('stepper-popup').classList.add('hidden');
    document.querySelectorAll('.step').forEach(el => el.classList.remove('active'));
}

async function nextStep(step) {
    document.querySelectorAll('.step').forEach(el => el.classList.remove('active'));
    document.querySelector(`.step-${step}`).classList.add('active');

    if (step === 2) {
        await loadCrustOptions(); // Load crust options when moving to step 2
    } else if (step === 3) {
        const chosenSizeId = document.querySelector('input[name="size"]:checked').value;
        const chosenCrustId = document.querySelector('input[name="crust"]:checked').value;

        const chosenSizeName = localStorage.getItem('selectedSize');
        const chosenCrustName = localStorage.getItem('selectedCrustName');

        const selectedCrust = document.querySelector('input[name="crust"]:checked');
        console.log(selectedCrust);
        if (selectedCrust) {
            const selectedCrustCost = selectedCrust.dataset.cost;
            // You can update the price display or perform other actions based on the selected crust
            console.log(`Selected Crust Cost: ₹${selectedCrustCost}`);
        }
        document.getElementById('chosen-size').textContent = chosenSizeName;
        document.getElementById('chosen-crust').textContent = chosenCrustName;
    } else if (step === 4) {
        const chosenToppings = Array.from(document.querySelectorAll('input[name="topping"]:checked'))
            .map(checkbox => checkbox.value)
            .join(', ');
        document.getElementById('chosen-toppings').textContent = chosenToppings;
    }
}
function addToCart(pizza) {
    var pizzaId = pizza.pizzaId;
    console.log(`Added to cart: ${pizza.pizzaId}`);
    localStorage.setItem('pizzaId', pizza.pizzaId);
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

async function fetchCrustCosts(pizzaId, sizeId) {
    try {

        const response = await fetch(`https://localhost:7028/api/Crust/cost${pizzaId}?SizeId=${sizeId}`);
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const crustCosts = await response.json();
        return crustCosts;
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
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

            // Create debug banner
            const debugBanner = document.createElement('div');
            debugBanner.className = 'debug-banner';
            debugBanner.textContent = '5% Discount';
            card.appendChild(debugBanner);
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
