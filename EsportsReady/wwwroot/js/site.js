const x = document.querySelectorAll(".p-product-cards");

const cardColours = [
	"#8DD6BC",
	"#75C1EB",
	"#9998EB",
	"#D579DD",
	"#F1CB93",
	"#F27F94",
];

for (let i = 0; i < x.length; i++) {
	x[i].style.backgroundColor = cardColours[i];
}
