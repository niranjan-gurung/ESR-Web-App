const x = document.querySelectorAll(".product-cards");

const cardColours = [
	"#8DD6BC",
	"#75C1EB",
	"#9998EB",
	"#D579DD",
	"#F1CB93",
	"#F27F94",
];

let colourIndex = 0;

for (let i = 0; i < x.length; i++) {
	if (colourIndex > 5)
		colourIndex = 0;

	x[i].style.backgroundColor = cardColours[colourIndex];
	colourIndex++;
}