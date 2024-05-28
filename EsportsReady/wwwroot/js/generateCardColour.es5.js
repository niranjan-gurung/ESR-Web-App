"use strict";

var x = document.querySelectorAll(".product-cards");

var cardColours = ["#8DD6BC", "#75C1EB", "#9998EB", "#D579DD", "#F1CB93", "#F27F94"];

var colourIndex = 0;

for (var i = 0; i < x.length; i++) {
	if (colourIndex > 5) colourIndex = 0;

	x[i].style.backgroundColor = cardColours[colourIndex];
	colourIndex++;
}

