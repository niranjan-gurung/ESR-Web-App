function confirmDelete(uniqueId, isDeleteClicked) {
	var deleteSpan = 'delete-span_' + uniqueId;
	var confirmDeleteSpan = 'confirm-delete-span_' + uniqueId;

	if (isDeleteClicked) {
		$('#' + deleteSpan).hide();
		$('#' + confirmDeleteSpan).show();
	}
	else {
		$('#' + deleteSpan).show();
		$('#' + confirmDeleteSpan).hide();
	}
}