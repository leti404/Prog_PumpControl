function toggleAdditionalFields() {
    const searchBy = document.getElementById("search-by").value;
    const additionalFieldsContainer = document.getElementById("additionalFields");
    additionalFieldsContainer.innerHTML = "";
    if (searchBy === "2") { // Código
        additionalFieldsContainer.innerHTML = `
            <label for="codiCorto">Código Corto:</label>
            <select asp-for="CodiCorto" class="inputdatos" id="codiCorto">
                <option value="" selected>Seleccione un código</option>
                <option value="A">Opción A</option>
                <option value="B">Opción B</option>
                <option value="C">Opción C</option>
            </select>
        `;
    } else if (searchBy === "5") { // Fabricante
        additionalFieldsContainer.innerHTML = `
            <label for="fabricanteNomb">Fabricante:</label>
            <select asp-for="FabricanteNomb" class="inputdatos" id="fabricanteNomb">
                <option value="" selected>Seleccione un fabricante</option>
                <option value="X">Fabricante X</option>
                <option value="Y">Fabricante Y</option>
                <option value="Z">Fabricante Z</option>
            </select>
        `;
    }
}