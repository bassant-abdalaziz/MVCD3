var employee = document.getElementById("EmpSSN");
var projectsArea = document.getElementById("projectsArea");
var projectInput = document.getElementById("projNum");
var HourArea = document.getElementById("HourArea");




employee.addEventListener("change", async () => {
    var projectsResult = await fetch("http://localhost:5082/worksOnProject/EmpHour/" + employee.value);
    projectList = await projectsResult.text();
    /*console.log(projectList);*/

    projectsArea.innerHTML = projectList;
    projectInput = document.getElementById("projNum");
    if (projectInput.value) {
        var hourResult = await fetch("http://localhost:5082/worksOnProject/EmpProject/" + employee.value + "?projNum=" + projectInput.value);
        hour = await hourResult.text();
        HourArea.innerHTML = hour;
    }

    projectInput.addEventListener("change", async () => {

        console.log(projectInput);
        var hourResult = await fetch("http://localhost:5082/worksOnProject/EmpProject/" + employee.value + "?projNum=" + projectInput.value);
        hour = await hourResult.text();
        HourArea.innerHTML = hour;

    });

});


