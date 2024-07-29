function openStepper() {
    document.getElementById('stepper-popup').classList.remove('hidden');
    document.querySelector('.step-1').classList.add('active');
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

function addToCart() {
    const size = document.querySelector('input[name="size"]:checked').value;
    const crust = document.querySelector('input[name="crust"]:checked').value;
    const toppings = Array.from(document.querySelectorAll('input[name="topping"]:checked'))
        .map(checkbox => checkbox.value)
        .join(', ');

    console.log(`Added to cart: Size - ${size}, Crust - ${crust}, Toppings - ${toppings}`);

    closeStepper();
}
async function fetchPizzas() {
    try {
        const response = await fetch('https://localhost:7028/api/Pizza');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const pizzas = await response.json();
        displayItems(pizzas, 'pizza');
    } catch (error) {
        console.error('There was a problem with the fetch operation:', error);
    }
}

function displayItems(items, type) {
    const container = type === 'pizza' ? document.getElementById('pizzaList') : document.getElementById('beverageContainer');
    container.innerHTML = ''; // Clear existing content

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

        const button = document.createElement('button');
        button.textContent = 'Add';
        button.classList.add('button');

        const name = document.createElement('h2');
        name.classList.add('title');
        name.textContent = item.name || 'No Name';

        const description = document.createElement('p');
        description.classList.add('description');
        description.textContent = item.description || 'No Description';

        const volume = document.createElement('p');
        volume.classList.add('volume');
        volume.textContent = `Price: ${cost}`;

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

fetchPizzas();