//[Data Table Javascript]

//Project:	Unique Admin - Responsive Admin Template
//Primary use:   Used only for the Data Table

$(function () {
    "use strict";
     
	$('#dataTable_crypto').DataTable({
      'paging'      : false,
      'lengthChange': true,
      'searching'   : true,
      'ordering'    : true,
      'info'        : true,
      'autoWidth'   : false
    });
	
	/*--- Sparkline charts - mini charts ---*/ 
	function sparkline_charts() {
		$('.sparklines').sparkline('html');
	}
	if ($('.sparklines').length) {
		sparkline_charts();
	} 
	
  }); // End of use strict