Оставшиеся вопросы.
1. В методе
public IReadOnlyList<Sku> Get()
	=> SkuList.Values.ToList().AsReadOnly();
нужно ли выполнять AsReadOnly?
Ведь если не выполнять, будет передан изменяемый объект через переменную типа IReadOnlyList.
Его можно будет сохранить (привести к типу) в переменную типа IList и затем изменять содержимое?