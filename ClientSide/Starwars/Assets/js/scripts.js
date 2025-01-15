async function fetchData(apiUrl) {
    try {
        const response = await fetch(apiUrl);
        if (!response.ok) {
            throw new Error(`HTTP error! status: ${response.status}`);
        }
        const data = await response.json();
        console.log('Data fetched:', data);
        return data;
    } catch (error) {
        console.error('Error fetching data:', error);
        return null;
    }
}

let people;
let planets;
let films;
window.onload = () => {
    fetchData("https://swapi.py4e.com/api/people/").then(data => {
        if (data) {
            people = data.results;
            console.log('Fetched data stored in variable:', data);
        }
    });
    fetchData("https://swapi.py4e.com/api/planets/").then(data => {
        if (data) {
            planets = data.results;
            console.log('Fetched data stored in variable:', data);
        }
    });
    fetchData("https://swapi.py4e.com/api/films/").then(data => {
        if (data) {
            films = data.results;
            console.log('Fetched data stored in variable:', data);
        }
    });
};

function search() {
    const query = document.getElementById('searchInput').value.toLowerCase();
    const suggestions = document.getElementById('suggestions');
    suggestions.innerHTML = ''; // Clear previous suggestions

    if (query) {
        const filteredSuggestions = characterList.filter(character => character.toLowerCase().includes(query));

        filteredSuggestions.forEach(character => {
            const option = document.createElement('option');
            option.value = character;
            suggestions.appendChild(option);
        });
    }
}

function LoadPeople() {
    const peopleElement = document.getElementById("people");
}