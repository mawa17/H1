let people;
let planets;
let films;

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

function LoadData(array) {
    const DATA_LIST = document.getElementById('suggestions');
    DATA_LIST.innerHTML = '';
    array.forEach(x => {
        const option = document.createElement('option');
        option.value = x;
        DATA_LIST.appendChild(option);
    });
}
function Search(name) {
    const query = document.getElementById('searchInput').value.toLowerCase();
    const filteredPeople = people.filter(person => person.name.toLowerCase().includes(query));
    ShowPeople(filteredPeople);
}



function ShowPeople(array) {
    const nav = document.querySelector('#container > .people');
    
    const existingUl = nav.querySelector('ul');
    if (existingUl) {
        nav.removeChild(existingUl);
    }

    const ul = document.createElement('ul');
    array.forEach(person => {
        const li = document.createElement('li');
        li.textContent = person.name;
        
        const nestedUl = document.createElement('ul');
        nestedUl.classList.add('nested');

        const heightLi = document.createElement('li');
        heightLi.textContent = `Height: ${person.height}`;
        nestedUl.appendChild(heightLi);

        const birthyearLi = document.createElement('li');
        birthyearLi.textContent = `Birth Year: ${person.birth_year}`;
        nestedUl.appendChild(birthyearLi);

        const genderLi = document.createElement('li');
        genderLi.textContent = `Gender: ${person.gender}`;
        nestedUl.appendChild(genderLi);

        li.appendChild(nestedUl);
        ul.appendChild(li);
    });
    nav.appendChild(ul);
}



window.onload = () => {
    fetchData("https://swapi.py4e.com/api/people/").then(data => {
        if (data) {
            people = data.results;
            console.log('Fetched data stored in variable:', data);
        }
        ShowPeople(people);
        LoadData(people.flatMap(x => x.name));
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
