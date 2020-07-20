export class Employee {
    id: string;
    name: string;
    surname: string;
    salary: number;
    lastJobTitle: string;
    hiredAt: Date;
    leftAt: Date;

    public static assemble(dto: any) {
        const result = new Employee();
        if (dto) {
            result.id = dto.id;
            result.name = dto.name + ' ' + dto.surname;

            const lastJob = dto.positions.sort((a, b) => {
                const lastJobDiff = b.hiredAt - a.hiredAt;
                if (lastJobDiff) { return lastJobDiff; }
            })[0];

            result.lastJobTitle = lastJob.title;
            result.hiredAt = lastJob.hiredAt;
            result.leftAt = lastJob.leftAt;
            result.salary = lastJob.salary;
        }
        return result;
    }
}
