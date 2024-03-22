var Common = {
    ConvertUtcDate(inputDate) { 
        const date = new Date(inputDate)  
        return date.toLocaleDateString();
    }
}