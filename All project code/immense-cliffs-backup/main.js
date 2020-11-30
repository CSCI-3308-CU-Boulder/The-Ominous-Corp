const themeToggleBtn = document.querySelector("#theme-toggle-btn");
const toggleIcon = document.querySelector(".toggle-icon");

themeToggleBtn.addEventListener("change",function(){	
	if(this.checked){
		document.documentElement.setAttribute('data-theme','dark');
			toggleIcon.classList.remove("fa-moon");
			toggleIcon.classList.add("fa-sun");
	}else{
		document.documentElement.setAttribute('data-theme','light');
			toggleIcon.classList.remove("fa-sun");
			toggleIcon.classList.add("fa-moon");
	}
})